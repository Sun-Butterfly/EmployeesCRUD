using FluentResults;
using MediatR;

namespace EmployeesCRUD.Mediatr.DeleteEmployee;

public record DeleteEmployeeRequest(long Id) : IRequest<Result<DeleteEmployeeResponse>>;