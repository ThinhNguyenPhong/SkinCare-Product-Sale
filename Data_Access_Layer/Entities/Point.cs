using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class Point
{
    public int PointId { get; set; }

    public int? AccountId { get; set; }

    public int Points { get; set; }

    public virtual Account? Account { get; set; }
}
