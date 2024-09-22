using EmployeesCRUD.Models;
using FluentResults;
using MediatR;

namespace EmployeesCRUD.Mediatr.SetNewDepartment;

public record SetNewDepartmentRequest(
    long EmployeeId,
    string DepartmentName
) : IRequest<Result<SetNewDepartmentResponse>>;