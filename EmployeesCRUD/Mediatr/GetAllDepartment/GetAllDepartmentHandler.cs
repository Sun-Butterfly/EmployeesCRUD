using EmployeesCRUD.DTOs;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.GetAllDepartment;

public class GetAllDepartmentHandler : IRequestHandler<GetAllDepartmentRequest, Result<GetAllDepartmentResponse>>
{
    private readonly DataBaseContext _db;

    public GetAllDepartmentHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<GetAllDepartmentResponse>> Handle(GetAllDepartmentRequest request,
        CancellationToken cancellationToken)
    {
        var departments = await _db.Departments.Select(x => 
            new DepartmentDto(
                x.Id, 
                x.Name
                )
        ).ToListAsync(cancellationToken: cancellationToken);
        return Result.Ok(new GetAllDepartmentResponse(departments));
    }
}