using FluentValidation;

namespace EmployeesCRUD.Mediatr.AddEmployee;

public class AddEmployeeValidator : AbstractValidator<AddEmployeeRequest>
{
    public AddEmployeeValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3).MaximumLength(25);
        
        RuleFor(x => x.SecondName)
            .MinimumLength(3).MaximumLength(25);
        
        RuleFor(x => x.LastName)
            .MinimumLength(3).MaximumLength(25);

        RuleFor(x => x.DateOfBirth)
            .LessThanOrEqualTo(DateTime.Now.AddYears(-18));

        RuleFor(x => x.DateOfEmployment)
            .LessThanOrEqualTo(DateTime.Today);

        RuleFor(x => x.DepartmentName)
            .MinimumLength(3);

        RuleFor(x => x.JobTitle)
            .IsInEnum();
    }
}