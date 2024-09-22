using FluentValidation;

namespace EmployeesCRUD.Mediatr.UpdateEmployee;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeRequest>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Name)
            .MinimumLength(3).MaximumLength(25);

        RuleFor(x => x.SecondName)
            .MinimumLength(3).MaximumLength(25);

        RuleFor(x => x.LastName)
            .MinimumLength(3).MaximumLength(25);

        RuleFor(x => x.DateOfBirth)
            .LessThanOrEqualTo(DateTime.Now.AddYears(-18));
    }
}