using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class FirmPagetable
{
    public int FNumber { get; set; }

    public string FPagename { get; set; } = null!;

    public string? FMessage { get; set; }

    public string? FPicurl { get; set; }

    public virtual FirmAccounttable FNumberNavigation { get; set; } = null!;
}
