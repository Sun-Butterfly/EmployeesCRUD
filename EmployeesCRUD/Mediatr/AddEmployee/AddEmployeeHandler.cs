using EmployeesCRUD.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace EmployeesCRUD.Mediatr.AddEmployee;

public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
{
    private readonly DataBaseContext _db;

    public AddEmployeeHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
    {
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

        return new AddEmployeeResponse(employee.Id);
    }
}