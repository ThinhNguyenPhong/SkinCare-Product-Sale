using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int? AccountId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Position { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
