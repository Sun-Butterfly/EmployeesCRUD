namespace EmployeesCRUD.Models;

public class JobTitle
{
    public enum JobTitles
    {
        Junior,
        Middle,
        Senior,
        TechLead,
        TeamLead
    }
    
    public JobTitles Title { get; set; }
    
    public int Salary { get; set; }
    public List<Employee> Employees { get; set; } = new();
}