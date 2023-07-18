using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class GroupDatatable
{
    public int GNumber { get; set; }

    public int FNumber { get; set; }

    public int PNumber { get; set; }

    public DateTime GStart { get; set; }

    public DateTime GEnd { get; set; }

    public int GMaxpeople { get; set; }

    public int GPrice { get; set; }

    public virtual FirmAccounttable FNumberNavigation { get; set; } = null!;

    public virtual ICollection<MemberMembertable> MemberMembertables { get; set; } = new List<MemberMembertable>();

    public virtual ProductDatatable PNumberNavigation { get; set; } = null!;
}
