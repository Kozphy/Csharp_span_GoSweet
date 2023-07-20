using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class CustomerAccounttable
{
    public string CNickname { get; set; } = null!;

    public int CNumber { get; set; }

    public string CAccount { get; set; } = null!;

    public string CPassword { get; set; } = null!;

    public bool CMailpass { get; set; }

    public virtual ICollection<NotifyDatatable> NotifyDatatables { get; set; } = new List<NotifyDatatable>();

    public virtual ICollection<OrderDatatable> OrderDatatables { get; set; } = new List<OrderDatatable>();

    public virtual ICollection<TalkDatatable> TalkDatatables { get; set; } = new List<TalkDatatable>();

    public virtual ICollection<TalkPersontable> TalkPersontables { get; set; } = new List<TalkPersontable>();
}
