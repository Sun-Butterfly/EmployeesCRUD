using FluentResults;
using MediatR;

namespace EmployeesCRUD.Mediatr.GetEmployeesByDepartment;

public record GetEmployeesByDepartmentRequest(string DepartmentName) : IRequest<Result<GetEmployeesByDepartmentResponse>>;