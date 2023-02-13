using System;
using System.Collections.Generic;

namespace DAL.Data;

public partial class Employee
{
    public string Fname { get; set; }

    public string Lname { get; set; }

    public int Ssn { get; set; }

    public DateTime? Bdate { get; set; }

    public string Address { get; set; }

    public string Sex { get; set; }

    public int? Salary { get; set; }

    public int? Superssn { get; set; }

    public int? Dno { get; set; }

    public virtual ICollection<Department> Departments { get; } = new List<Department>();

    public virtual ICollection<Dependent> Dependents { get; } = new List<Dependent>();

    public virtual Department DnoNavigation { get; set; }

    public virtual ICollection<Employee> InverseSuperssnNavigation { get; } = new List<Employee>();

    public virtual Employee SuperssnNavigation { get; set; }

    public virtual ICollection<WorksFor> WorksFors { get; } = new List<WorksFor>();
}
