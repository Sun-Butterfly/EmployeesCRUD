using EmployeesCRUD.Models;

namespace EmployeesCRUD.DTOs;

public record UpdateEmployeeRequestDto(
    long Id,
    string Name,
    string SecondName,
    string LastName,
    DateTime DateOfBirth
);