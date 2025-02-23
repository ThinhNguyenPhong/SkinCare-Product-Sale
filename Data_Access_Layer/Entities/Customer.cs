using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int? AccountId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual Account? Account { get; set; }
}
