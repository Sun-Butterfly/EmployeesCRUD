using EmployeesCRUD.DTOs;
using EmployeesCRUD.Models;

namespace EmployeesCRUD.Mediatr.GetEmployeesByDepartment;

public record GetEmployeesByDepartmentResponse(List<EmployeeDto> Employees);