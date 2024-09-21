using EmployeesCRUD.Models;
using FluentResults;
using MediatR;

namespace EmployeesCRUD.Mediatr.SetNewJobTitle;

public record SetNewJobTitleRequest(long EmployeeId, JobTitle.JobTitles JobTitle) 
    : IRequest<Result<SetNewJobTitleResponse>>;