using System;
using System.Collections.Generic;

namespace DAL.Data;

public partial class Dependent
{
    public int Essn { get; set; }

    public string DependentName { get; set; }

    public string Sex { get; set; }

    public DateTime? Bdate { get; set; }

    public virtual Employee EssnNavigation { get; set; }
}
