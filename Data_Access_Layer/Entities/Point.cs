using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities;

public partial class Point
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PointId { get; set; }

    public int? AccountId { get; set; }

    public int Points { get; set; }

    public virtual Account? Account { get; set; }
}
