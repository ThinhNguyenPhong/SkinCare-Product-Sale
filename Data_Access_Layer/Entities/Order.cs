using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int? AccountId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Account? Account { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<OrderPromotion> OrderPromotions { get; set; } = new List<OrderPromotion>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
