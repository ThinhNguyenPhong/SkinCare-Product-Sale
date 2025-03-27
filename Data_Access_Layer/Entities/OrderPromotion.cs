using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities;

public partial class OrderPromotion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderPromotionId { get; set; }

    public int? OrderId { get; set; }

    public int? PromotionId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Promotion? Promotion { get; set; }
}
