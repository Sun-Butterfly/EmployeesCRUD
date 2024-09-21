using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.SetNewJobTitle;

public class SetNewJobTitleHandler : IRequestHandler<SetNewJobTitleRequest, SetNewJobTitleResponse>
{
    private readonly DataBaseContext _db;

    public SetNewJobTitleHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<SetNewJobTitleResponse> Handle(SetNewJobTitleRequest request, CancellationToken cancellationToken)
    {
        var employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == request.EmployeeId);
        employee.CurrentJobTitle = request.JobTitle;
        _db.Update(employee);
        await _db.SaveChangesAsync(cancellationToken);

        return new SetNewJobTitleResponse();
    }
}