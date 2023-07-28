using System;
using System.Collections.Generic;

namespace ServicePlatform.Data.Models;

public partial class Il
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
