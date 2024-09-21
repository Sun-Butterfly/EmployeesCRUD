using EmployeesCRUD.Models;
using FluentResults;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace EmployeesCRUD.Mediatr.AddEmployee;

public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, Result<AddEmployeeResponse>>
{
    private readonly DataBaseContext _db;
    private readonly IValidator<AddEmployeeRequest> _validator;

    public AddEmployeeHandler(DataBaseContext db, IValidator<AddEmployeeRequest> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<Result<AddEmployeeResponse>> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Fail("Ошибка валидации. " + validationResult.Stringify());
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

        var employee = new Employee()
        {
            Name = request.Name,
            SecondName = request.SecondName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            DateOfEmployment = request.DateOfEmployment,
            Department = department, 
            CurrentJobTitle = request.JobTitle
        };
        _db.Add(employee);
        await _db.SaveChangesAsync(cancellationToken);

        return Result.Ok(new AddEmployeeResponse(employee.Id));
    }
}