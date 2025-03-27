using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities;

public partial class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeId { get; set; }

    public int? AccountId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Position { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
