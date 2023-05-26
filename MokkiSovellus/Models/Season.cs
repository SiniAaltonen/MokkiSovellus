using System;
using System.Collections.Generic;

namespace MokkiSovellus.Models;

public partial class Season
{
    public int Id { get; set; }

    public string? Season1 { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Work> Works { get; set; } = new List<Work>();
}
