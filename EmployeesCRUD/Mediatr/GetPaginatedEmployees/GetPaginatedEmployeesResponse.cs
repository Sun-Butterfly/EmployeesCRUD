using EmployeesCRUD.DTOs;

namespace EmployeesCRUD.Mediatr.GetPaginatedEmployees;

public record GetPaginatedEmployeesResponse(List<EmployeeDto> PaginatedEmployees, long TotalCount);