using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.GetSalary;

public class GetSalaryHandler : IRequestHandler<GetSalaryRequest, GetSalaryResponse>
{
    private readonly DataBaseContext _db;

    public GetSalaryHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<GetSalaryResponse> Handle(GetSalaryRequest request, CancellationToken cancellationToken)
    {
        var employee = await _db.Employees.Include(employee => employee.JobTitle).FirstOrDefaultAsync(x => 
            x.Id == request.Id, cancellationToken: cancellationToken);
        return new GetSalaryResponse(employee.JobTitle.Salary);
    }
}