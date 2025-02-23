using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class PromotionDetail
{
    public int PromotionDetailId { get; set; }

    public int? PromotionId { get; set; }

    public string DetailDescription { get; set; } = null!;

    public virtual Promotion? Promotion { get; set; }
}
