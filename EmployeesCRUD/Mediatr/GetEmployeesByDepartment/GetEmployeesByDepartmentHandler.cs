using EmployeesCRUD.DTOs;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.GetEmployeesByDepartment;

public class
    GetEmployeesByDepartmentHandler : IRequestHandler<GetEmployeesByDepartmentRequest, Result<GetEmployeesByDepartmentResponse>>
{
    private readonly DataBaseContext _db;

    public GetEmployeesByDepartmentHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<GetEmployeesByDepartmentResponse>> Handle(GetEmployeesByDepartmentRequest request,
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
        return Result.Ok(new GetEmployeesByDepartmentResponse(employees));
    }
}