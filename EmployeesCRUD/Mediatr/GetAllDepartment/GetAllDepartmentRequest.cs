using FluentResults;
using MediatR;

namespace EmployeesCRUD.Mediatr.GetAllDepartment;

public record GetAllDepartmentRequest() : IRequest<Result<GetAllDepartmentResponse>>;