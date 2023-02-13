using DAL;
using DAL.Data;
using System.Collections.Generic;
using System.Data;

namespace BLL;

public class BusinessLayer
{
    DataLayer dataLayer = new DataLayer();

    public Employee GetEmployee(string firstname)
    {
        return dataLayer.GetEmployee(firstname);
    }

    public int UpdateEmployee(Employee updatedEmp, string firstname)
    {
        return dataLayer.UpdateEmployee(updatedEmp, firstname);
    }

    public int DeleteEmployee(string firstname)
    {
        return dataLayer.DeleteEmployee(firstname);
    }

    public int InsertDepartment(Department dept)
    {
        return dataLayer.InsertDepartment(dept);
    }

    public List<Employee> GetEmplooyees()
    {
        DataTable dataTable = dataLayer.GetEmplooyees();
        List<Employee> employees = new List<Employee>();
        foreach (DataRow item in dataTable.Rows)
        {
            Employee employee = new Employee();
            int dno;

            bool res = int.TryParse(item["Dno"].ToString(), out dno);
            employee.Dno = res ? dno : 0;
            employee.Fname = item["Fname"].ToString();
            employee.Lname = item["Lname"].ToString();
            decimal sal;

            res = decimal.TryParse(item["Salary"].ToString(), out sal);
            employee.Salary = res ? (int)sal : 0;
            employees.Add(employee);
        }
        return employees;
    }
    public List<Department> GetDepartments()
    {
        DataTable dataTable = dataLayer.GetDepartments();
        List<Department> departments = new List<Department>();
        foreach (DataRow item in dataTable.Rows)
        {
            Department department = new Department();
            department.Dnum = (int)item["Dnum"];
            department.Dname = item["Dname"].ToString();
            departments.Add(department);
        }
        return departments;
    }
    public int InsertEmployee(string fname, string lname, decimal salary, int dno)
    {
        int count = dataLayer.InsertEmployee(fname, lname, salary, dno);
        return count;
    }
}
