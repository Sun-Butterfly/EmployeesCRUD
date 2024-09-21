using EmployeesCRUD.Models;
using MediatR;

namespace EmployeesCRUD.Mediatr.SetNewJobTitle;

public record SetNewJobTitleRequest(long EmployeeId, JobTitle.JobTitles JobTitle) : IRequest<SetNewJobTitleResponse>;