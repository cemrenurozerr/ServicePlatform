using System;
using System.Collections.Generic;

namespace ServicePlatform.Data.Models;

public partial class Expert
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public int? RoleId { get; set; }

    public int? AddressId { get; set; }

    public int? ServiceId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Service? Service { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
