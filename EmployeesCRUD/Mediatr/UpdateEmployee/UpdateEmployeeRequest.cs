using EmployeesCRUD.Models;
using FluentResults;
using MediatR;

namespace EmployeesCRUD.Mediatr.UpdateEmployee;

public record UpdateEmployeeRequest(
    long Id,
    string Name,
    string SecondName,
    string LastName,
    DateTime DateOfBirth
) : IRequest<Result<UpdateEmployeeResponse>>;