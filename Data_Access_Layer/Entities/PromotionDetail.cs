using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities;

public partial class PromotionDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PromotionDetailId { get; set; }

    public int? PromotionId { get; set; }

    public string DetailDescription { get; set; } = null!;

    public virtual Promotion? Promotion { get; set; }
}
