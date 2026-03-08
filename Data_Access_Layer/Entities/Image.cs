using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities;

public partial class Image
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ImageId { get; set; }

    public string? ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
