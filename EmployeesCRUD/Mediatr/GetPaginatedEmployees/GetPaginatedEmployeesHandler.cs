using EmployeesCRUD.DTOs;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.GetPaginatedEmployees;

public class
    GetPaginatedEmployeesHandler : IRequestHandler<GetPaginatedEmployeesRequest, Result<GetPaginatedEmployeesResponse>>
{
    private readonly DataBaseContext _db;

    public GetPaginatedEmployeesHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<GetPaginatedEmployeesResponse>> Handle(GetPaginatedEmployeesRequest request,
        CancellationToken cancellationToken)
    {
        var query = _db.Employees.Select(x =>
            new EmployeeDto(
                x.Id,
                x.Name,
                x.SecondName,
                x.LastName,
                x.DateOfBirth,
                x.DateOfEmployment,
                x.Department.Name,
                x.CurrentJobTitle,
                x.JobTitle.Salary));
        var totalCount = await query.LongCountAsync(cancellationToken: cancellationToken);
        var paginatedEmployees = await query
            .Skip((request.CurrentPage - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken: cancellationToken);
        return Result.Ok(new GetPaginatedEmployeesResponse(paginatedEmployees, totalCount));
    }
}