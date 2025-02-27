﻿using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class Image
{
    public int ImageId { get; set; }

    public string? ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
