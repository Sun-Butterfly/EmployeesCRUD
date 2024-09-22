using EmployeesCRUD.Models;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.SetNewDepartment;

public class SetNewDepartmentHandler : IRequestHandler<SetNewDepartmentRequest, Result<SetNewDepartmentResponse>>
{
    private readonly DataBaseContext _db;
    private readonly IValidator<SetNewDepartmentRequest> _validator;

    public SetNewDepartmentHandler(DataBaseContext db, IValidator<SetNewDepartmentRequest> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<Result<SetNewDepartmentResponse>> Handle(SetNewDepartmentRequest request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Fail("Ошибка валидации. " + validationResult.Stringify());
        }

        var employee =
            await _db.Employees.FirstOrDefaultAsync(x => x.Id == request.EmployeeId,
                cancellationToken: cancellationToken);
        if (employee == null)
        {
            return Result.Fail("Работник не найден");
        }

        var department = await _db.Departments.FirstOrDefaultAsync(x => x.Name == request.DepartmentName,
            cancellationToken: cancellationToken);
        if (department == null)
        {
            department = new Department()
            {
                Name = request.DepartmentName
            };
            _db.Add(department);
            await _db.SaveChangesAsync(cancellationToken);
        }

        employee.Department = department;
        _db.Employees.Update(employee);
        await _db.SaveChangesAsync(cancellationToken);

        return Result.Ok(new SetNewDepartmentResponse() );
    }
}