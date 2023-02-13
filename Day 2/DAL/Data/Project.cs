using System;
using System.Collections.Generic;

namespace DAL.Data;

public partial class Project
{
    public string Pname { get; set; }

    public int Pnumber { get; set; }

    public string Plocation { get; set; }

    public string City { get; set; }

    public int? Dnum { get; set; }

    public virtual Department DnumNavigation { get; set; }

    public virtual ICollection<WorksFor> WorksFors { get; } = new List<WorksFor>();
}
