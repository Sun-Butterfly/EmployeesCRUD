using EmployeesCRUD.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.GetAllDepartment;

public class GetAllDepartmentHandler : IRequestHandler<GetAllDepartmentRequest, GetAllDepartmentResponse>
{
    private readonly DataBaseContext _db;

    public GetAllDepartmentHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<GetAllDepartmentResponse> Handle(GetAllDepartmentRequest request,
        CancellationToken cancellationToken)
    {
        var departments = await _db.Departments.Select(x => 
            new DepartmentDto(
                x.Id, 
                x.Name
                )
        ).ToListAsync(cancellationToken: cancellationToken);
        return new GetAllDepartmentResponse(departments);
    }
}