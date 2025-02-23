using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class ProductPromotion
{
    public int ProductPromotionId { get; set; }

    public string? ProductId { get; set; }

    public int? PromotionId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Promotion? Promotion { get; set; }
}
