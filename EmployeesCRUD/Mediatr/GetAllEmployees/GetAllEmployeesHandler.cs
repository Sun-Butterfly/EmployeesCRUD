using EmployeesCRUD.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.GetAllEmployees;

public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesRequest, GetAllEmployeesResponse>
{
    private readonly DataBaseContext _db;

    public GetAllEmployeesHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<GetAllEmployeesResponse> Handle(GetAllEmployeesRequest request, CancellationToken cancellationToken)
    {
        var employees = await _db.Employees.Select(x =>
            new EmployeeDto(
                x.Id,
                x.Name,
                x.SecondName,
                x.LastName,
                x.DateOfBirth,
                x.DateOfEmployment,
                x.Department.Name,
                x.CurrentJobTitle,
                x.JobTitle.Salary)).ToListAsync(cancellationToken: cancellationToken);
        return new GetAllEmployeesResponse(employees);
    }
}