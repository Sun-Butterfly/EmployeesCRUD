namespace EmployeesCRUD.Models;

public class Employee
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string SecondName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfEmployment { get; set; }
    public Department Department { get; set; } = null!;
    public long DepartmentId { get; set; }
    public JobTitle.JobTitles CurrentJobTitle { get; set; }
    public JobTitle JobTitle { get; set; } = null!;
}