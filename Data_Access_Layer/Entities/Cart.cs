using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class Cart
{
    public int CartId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
