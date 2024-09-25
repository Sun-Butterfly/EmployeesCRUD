using EmployeesCRUD.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.GetEmployeesByDepartment;

public class
    GetEmployeesByDepartmentHandler : IRequestHandler<GetEmployeesByDepartmentRequest, GetEmployeesByDepartmentResponse>
{
    private readonly DataBaseContext _db;

    public GetEmployeesByDepartmentHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<GetEmployeesByDepartmentResponse> Handle(GetEmployeesByDepartmentRequest request,
        CancellationToken cancellationToken)
    {
        var employees = await _db.Employees
            .Where(x => x.Department.Name == request.DepartmentName)
            .Select(x =>
                new EmployeeDto(
                    x.Id,
                    x.Name,
                    x.SecondName,
                    x.LastName,
                    x.DateOfBirth,
                    x.DateOfEmployment,
                    x.Department.Name,
                    x.CurrentJobTitle,
                    x.JobTitle.Salary
                )
            )
            .ToListAsync(cancellationToken: cancellationToken);
        return new GetEmployeesByDepartmentResponse(employees);
    }
}