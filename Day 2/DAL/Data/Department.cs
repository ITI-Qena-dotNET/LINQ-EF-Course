using System;
using System.Collections.Generic;

namespace DAL.Data;

public partial class Department
{
    public string Dname { get; set; }

    public int Dnum { get; set; }

    public int? Mgrssn { get; set; }

    public DateTime? MgrstartDate { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual Employee MgrssnNavigation { get; set; }

    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
