using EmployeesCRUD.Interfaces;
using EmployeesCRUD.Services;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.DeleteEmployee;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, Result<DeleteEmployeeResponse>>
{
    private readonly DataBaseContext _db;
    private readonly IService _service;

    public DeleteEmployeeHandler(DataBaseContext db, IService service)
    {
        _db = db;
        _service = service;
    }

    public async Task<Result<DeleteEmployeeResponse>> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
    {
        if (!_service.EmployeeExistsById(request.Id))
        {
            return Result.Fail("Работник не найден");
        }
        
        await _db.Employees.Where(x => x.Id == request.Id).ExecuteDeleteAsync(cancellationToken);

        return Result.Ok(new DeleteEmployeeResponse());
    }
}