public class EmployeeDatabase
{
    private readonly IDbConnection _databaseConnection;

    public EmployeeDatabase(IDbConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    public Employee GetEmployee(int id)
    {
        return _databaseConnection.QueryFirstOrDefault<Employee>("SELECT * FROM Employees WHERE Id = @Id", new { Id = id });
    }

    public void SaveEmployee(Employee emp)
    {
        _databaseConnection.Execute("UPDATE Employees SET Name = @Name WHERE Id = @Id", new { emp.Name, emp.Id });
    }

    public void DeleteEmployee(int id)
    {
        _databaseConnection.Execute("DELETE FROM Employees WHERE Id = @Id", new { Id = id });
    }
}


public class EmployeeService
{
    private int const maxNameLength = 150;
    private int const chairmansEmpId = 1;
    private int const empIdStartingRange = 50;

    private readonly EmployeeDatabase _employeeDatabase;

    public EmployeeService(EmployeeDatabase employeeDatabase)
    {
        _employeeDatabase = employeeDatabase;
    }

    public Employee GetEmployee(int id)
    {
        if (id < empIdStartingRange)
            throw new InvalidDataException("Employee ID starts from 50. 1 to 49 are reserved for promoters, investors, etc. Data can't be shared due to security issues.");

        return _employeeDatabase.GetEmployee(id);
    }

    public void UpdateEmployee(Employee emp)
    {
        if (emp.Name.Length > maxNameLength)
            throw new InvalidDataException("Name is too long.");
        _employeeDatabase.SaveEmployee(emp);
    }

    public void RemoveEmployee(int id)
    {
        if (id == chairmansEmpId)
            throw new InvalidDataException("Chairman can't be removed.");
        _employeeDatabase.DeleteEmployee(id);
    }
}