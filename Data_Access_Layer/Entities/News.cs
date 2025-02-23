using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class News
{
    public int NewsId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
