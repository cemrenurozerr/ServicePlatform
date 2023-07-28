using System;
using System.Collections.Generic;

namespace ServicePlatform.Data.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsCompleted { get; set; }

    public bool? IsExpertApproved { get; set; }

    public string? Message { get; set; }

    public int? ExpertId { get; set; }

    public int? ServiceId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Expert? Expert { get; set; }

    public virtual Service? Service { get; set; }
}
