using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace DAL;

public class DataLayer
{
    private CompanySdContext _context;

    public DataLayer()
    {
        _context = new CompanySdContext();
    }

    public Employee GetEmployee(string name)
    {
        return _context.Employees.FirstOrDefault(x => x.Fname == name);
    }

    public int UpdateEmployee(Employee updatedEmployee, string name)
    {
        var emp = _context.Employees.FirstOrDefault(x => x.Fname == name);
        emp.Salary = updatedEmployee.Salary;
        _context.Employees.Update(emp);
        //_context.Entry(emp).State = EntityState.Modified;

        return _context.SaveChanges();
    }

    public int DeleteEmployee(string name)
    {
        var emp = _context.Employees.FirstOrDefault(x => x.Fname == name);
        _context.Employees.Remove(emp);
        //_context.Entry(emp).State = EntityState.Deleted;

        return _context.SaveChanges();
    }

    public int InsertDepartment(Department dept)
    {
        _context.Departments.Add(dept);
        //_context.Entry(emp).State = EntityState.Added;
        return _context.SaveChanges();
    }

    public DataTable GetEmplooyees()
    {
        var res = _context.Employees.ToDataTable();
        return res;
    }

    public DataTable GetDepartments()
    {
        var res = _context.Departments.ToDataTable();
        return res;
    }
    public int InsertEmployee(string fname, string lname, decimal salary, int dno)
    {
        Employee emp = new()
        {
            Ssn = Random.Shared.Next(1, 9999999),
            Fname = fname,
            Lname = lname,
            Salary = (int)salary,
            Dno = dno,
        };

        _context.Employees.Add(emp);
        //_context.Entry(emp).State = EntityState.Added;
        return _context.SaveChanges();
    }
}
