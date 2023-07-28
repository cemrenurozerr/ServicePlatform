using System;
using System.Collections.Generic;

namespace ServicePlatform.Data.Models;

public partial class Role
{
    public int Id { get; set; }

    public bool? UserType { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Expert> Experts { get; set; } = new List<Expert>();
}
