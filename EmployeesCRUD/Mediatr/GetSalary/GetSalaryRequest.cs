using MediatR;

namespace EmployeesCRUD.Mediatr.GetSalary;

public record GetSalaryRequest(long Id) : IRequest<GetSalaryResponse>;