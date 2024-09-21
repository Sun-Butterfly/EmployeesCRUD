using MediatR;

namespace EmployeesCRUD.Mediatr.GetEmployeesByDepartment;

public record GetEmployeesByDepartmentRequest(string DepartmentName) : IRequest<GetEmployeesByDepartmentResponse>;