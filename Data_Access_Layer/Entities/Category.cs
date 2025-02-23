using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities;

public partial class Category
{
    public string? CategoryId { get; set; }

    [Required(ErrorMessage = "Category name is required")]
    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
