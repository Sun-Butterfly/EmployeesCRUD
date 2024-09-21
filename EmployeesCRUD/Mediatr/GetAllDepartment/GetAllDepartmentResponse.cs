using EmployeesCRUD.DTOs;

namespace EmployeesCRUD.Mediatr.GetAllDepartment;

public record GetAllDepartmentResponse(List<DepartmentDto> Departments);