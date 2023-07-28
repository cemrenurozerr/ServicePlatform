using System;
using System.Collections.Generic;

namespace ServicePlatform.Data.Models;

public partial class Address
{
    public int Id { get; set; }

    public int? IlId { get; set; }

    public int? IlceId { get; set; }

    public int? MahalleId { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Expert> Experts { get; set; } = new List<Expert>();

    public virtual Il? Il { get; set; }

    public virtual Ilce? Ilce { get; set; }

    public virtual Mahalle? Mahalle { get; set; }
}
