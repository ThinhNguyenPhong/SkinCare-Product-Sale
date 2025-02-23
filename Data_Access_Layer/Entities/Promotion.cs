using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Discount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual ICollection<OrderPromotion> OrderPromotions { get; set; } = new List<OrderPromotion>();

    public virtual ICollection<ProductPromotion> ProductPromotions { get; set; } = new List<ProductPromotion>();

    public virtual ICollection<PromotionDetail> PromotionDetails { get; set; } = new List<PromotionDetail>();
}
