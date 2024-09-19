namespace EmployeesCRUD.Models;

public class Department
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public List<Employee> Employees { get; set; } = new();
}