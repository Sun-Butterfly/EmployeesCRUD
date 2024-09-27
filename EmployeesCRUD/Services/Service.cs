using EmployeesCRUD.Interfaces;

namespace EmployeesCRUD.Services;

public class Service : IService
{
    private readonly DataBaseContext _db;

    public Service(DataBaseContext db)
    {
        _db = db;
    }

    public bool EmployeeExistsById(long id)
    {
        var employee = _db.Employees
            .FirstOrDefault(x => x.Id == id);
        if (employee == null)
        {
            return false;
        }

        return true;
    }
}