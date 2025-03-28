﻿using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class Product
{
    public string? ProductId { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public bool IsActive { get; set; } = true; // Default to active

    public string? Description { get; set; }

    public string? CategoryId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<ProductPromotion> ProductPromotions { get; set; } =
        new List<ProductPromotion>();
}
