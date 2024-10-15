using FluentResults;
using MediatR;

namespace EmployeesCRUD.Mediatr.GetPaginatedEmployees;

public record GetPaginatedEmployeesRequest(int CurrentPage, int PageSize) : IRequest<Result<GetPaginatedEmployeesResponse>>;