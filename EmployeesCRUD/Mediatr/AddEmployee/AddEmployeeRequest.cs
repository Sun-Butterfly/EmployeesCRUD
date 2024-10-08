using EmployeesCRUD.Models;
using FluentResults;
using MediatR;

namespace EmployeesCRUD.Mediatr.AddEmployee;

public record AddEmployeeRequest(
    string Name,
    string SecondName,
    string LastName,
    DateTime DateOfBirth,
    DateTime DateOfEmployment,
    string DepartmentName,
    JobTitle.JobTitles JobTitle
) : IRequest<Result<AddEmployeeResponse>>;
