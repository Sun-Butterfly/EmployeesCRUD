using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesCRUD.Mediatr.SetNewJobTitle;

public class SetNewJobTitleHandler : IRequestHandler<SetNewJobTitleRequest, Result<SetNewJobTitleResponse>>
{
    private readonly DataBaseContext _db;
    private readonly IValidator<SetNewJobTitleRequest> _validator;

    public SetNewJobTitleHandler(DataBaseContext db, IValidator<SetNewJobTitleRequest> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<Result<SetNewJobTitleResponse>> Handle(SetNewJobTitleRequest request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Fail("Ошибка валидации. " + validationResult.Stringify());
        }
        var employee =
            await _db.Employees.FirstOrDefaultAsync(x => x.Id == request.EmployeeId,
                cancellationToken: cancellationToken);

        if (employee == null)
        {
            return Result.Fail("Работник не найден");
        }

        employee.CurrentJobTitle = request.JobTitle;
        _db.Update(employee);
        await _db.SaveChangesAsync(cancellationToken);

        return Result.Ok(new SetNewJobTitleResponse());
    }
}