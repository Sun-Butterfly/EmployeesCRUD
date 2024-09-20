using EmployeesCRUD.Models;

namespace EmployeesCRUD.DTOs;

public record AddEmployeeRequestDto(
    string Name,
    string SecondName,
    string LastName,
    DateTime DateOfBirth,
    DateTime DateOfEmployment,
    string DepartmentName,
    JobTitle.JobTitles JobTitle
);