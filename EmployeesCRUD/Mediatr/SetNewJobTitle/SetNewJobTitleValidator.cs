using FluentValidation;

namespace EmployeesCRUD.Mediatr.SetNewJobTitle;

public class SetNewJobTitleValidator : AbstractValidator<SetNewJobTitleRequest>
{
    public SetNewJobTitleValidator()
    {
        RuleFor(x => x.EmployeeId)
            .GreaterThan(0);
    }
}