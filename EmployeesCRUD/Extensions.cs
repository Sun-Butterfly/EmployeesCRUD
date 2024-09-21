using FluentResults;
using FluentValidation.Results;

namespace EmployeesCRUD;

public static class Extensions
{
    //пристройка (расширение) к классу Result, чтобы не лезть в нугет, а написать метод снаружи
    public static string Stringify<T>(this Result<T> result)
    {
        return string.Join(";", result.Errors.Select(x => x.Message));
    }

    public static string Stringify(this ValidationResult result)
    {
        return string.Join(";", result.Errors.Select(x => x.ErrorMessage));
    }
}