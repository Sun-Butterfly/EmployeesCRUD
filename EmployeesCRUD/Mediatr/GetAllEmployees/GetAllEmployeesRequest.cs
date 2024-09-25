using MediatR;

namespace EmployeesCRUD.Mediatr.GetAllEmployees;

public record GetAllEmployeesRequest() : IRequest<GetAllEmployeesResponse>;