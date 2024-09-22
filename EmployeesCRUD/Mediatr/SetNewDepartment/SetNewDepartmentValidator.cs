using FluentValidation;

namespace EmployeesCRUD.Mediatr.SetNewDepartment;

public class SetNewDepartmentValidator : AbstractValidator<SetNewDepartmentRequest>
{
    public SetNewDepartmentValidator()
    {
        RuleFor(x => x.EmployeeId)
            .GreaterThan(0);
        
        RuleFor(x => x.DepartmentName)
            .MinimumLength(3);
    }
}