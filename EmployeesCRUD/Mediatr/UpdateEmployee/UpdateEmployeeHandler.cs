using EmployeesCRUD.Models;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.UpdateEmployee;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, Result<UpdateEmployeeResponse>>
{
    private readonly DataBaseContext _db;
    private readonly IValidator<UpdateEmployeeRequest> _validator;

    public UpdateEmployeeHandler(DataBaseContext db, IValidator<UpdateEmployeeRequest> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<Result<UpdateEmployeeResponse>> Handle(UpdateEmployeeRequest request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Fail("Ошибка валидации. " + validationResult.Stringify());
        }

        var employee =
            await _db.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        employee.Name = request.Name;
        employee.SecondName = request.SecondName;
        employee.LastName = request.LastName;
        employee.DateOfBirth = request.DateOfBirth;
        _db.Employees.Update(employee);
        await _db.SaveChangesAsync(cancellationToken);

        return Result.Ok(new UpdateEmployeeResponse());
    }
}