using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class TalkMembertable
{
    public int TalkMemberId { get; set; }

    public int CNumber { get; set; }

    public int FNumber { get; set; }

    public virtual CustomerAccounttable CNumberNavigation { get; set; } = null!;

    public virtual FirmAccounttable FNumberNavigation { get; set; } = null!;
}
