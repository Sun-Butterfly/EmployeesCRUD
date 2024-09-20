using EmployeesCRUD.Mediatr.GetEmployeesByDepartment;
using MediatR;

namespace EmployeesCRUD.Mediatr.GetEmployeeByDepartment;

public record GetEmployeesByDepartmentRequest(string DepartmentName) : IRequest<GetEmployeesByDepartmentResponse>;