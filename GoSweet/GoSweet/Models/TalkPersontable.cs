using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class TalkPersontable
{
    public int TForPk { get; set; }

    public int? CNumber { get; set; }

    public int? FNumber { get; set; }

    public string TId { get; set; } = null!;

    public virtual CustomerAccounttable? CNumberNavigation { get; set; }

    public virtual FirmAccounttable? FNumberNavigation { get; set; }
}
