using MediatR;

namespace EmployeesCRUD.Mediatr.GetAllDepartment;

public record GetAllDepartmentRequest() : IRequest<GetAllDepartmentResponse>;