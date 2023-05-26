using System;
using System.Collections.Generic;

namespace MokkiSovellus.Models;

public partial class Work
{
    public int Id { get; set; }

    public string? WorkName { get; set; }

    public string? WhenDuration { get; set; }

    public string? Equipment { get; set; }

    public int? SeasonId { get; set; }

    public int? WorkStatus { get; set; }

    public virtual Season? Season { get; set; }
}
