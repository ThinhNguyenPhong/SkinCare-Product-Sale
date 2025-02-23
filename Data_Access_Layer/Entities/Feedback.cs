using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? AccountId { get; set; }

    public string Content { get; set; } = null!;

    public int? Rating { get; set; }

    public virtual Account? Account { get; set; }
}
