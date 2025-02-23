using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class OrderPromotion
{
    public int OrderPromotionId { get; set; }

    public int? OrderId { get; set; }

    public int? PromotionId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Promotion? Promotion { get; set; }
}
