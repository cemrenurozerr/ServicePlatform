using System;
using System.Collections.Generic;

namespace ServicePlatform.Data.Models;

public partial class Service
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Expert> Experts { get; set; } = new List<Expert>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
