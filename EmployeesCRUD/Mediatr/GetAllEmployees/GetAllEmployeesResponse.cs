using EmployeesCRUD.DTOs;

namespace EmployeesCRUD.Mediatr.GetAllEmployees;

public record GetAllEmployeesResponse(List<EmployeeDto> Employees);