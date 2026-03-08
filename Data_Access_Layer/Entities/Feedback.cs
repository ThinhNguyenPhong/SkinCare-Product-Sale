using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities;

public partial class Feedback
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbackId { get; set; }

    public int? AccountId { get; set; }

    public string Content { get; set; } = null!;

    public int? Rating { get; set; }

    public virtual Account? Account { get; set; }
    public string ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
