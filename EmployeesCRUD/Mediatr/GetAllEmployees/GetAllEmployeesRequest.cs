using FluentResults;
using MediatR;

namespace EmployeesCRUD.Mediatr.GetAllEmployees;

public record GetAllEmployeesRequest() : IRequest<Result<GetAllEmployeesResponse>>;