using EmployeesCRUD.DTOs;

namespace EmployeesCRUD.Mediatr.GetEmployeesByDepartment;

public record GetEmployeesByDepartmentResponse(List<EmployeeDto> Employees);