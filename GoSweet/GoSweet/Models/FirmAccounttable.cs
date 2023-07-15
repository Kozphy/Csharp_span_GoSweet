using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class FirmAccounttable
{
    public int FNumber { get; set; }

    public string FNickname { get; set; } = null!;

    public string FAccount { get; set; } = null!;

    public string FPassword { get; set; } = null!;

    public bool FMailpass { get; set; }

    public virtual FirmPagetable? FirmPagetable { get; set; }

    public virtual ICollection<GroupDatatable> GroupDatatables { get; set; } = new List<GroupDatatable>();

    public virtual ICollection<NotifyDatatable> NotifyDatatables { get; set; } = new List<NotifyDatatable>();

    public virtual ICollection<OrderDatatable> OrderDatatables { get; set; } = new List<OrderDatatable>();

    public virtual ICollection<ProductDatatable> ProductDatatables { get; set; } = new List<ProductDatatable>();

    public virtual ICollection<TalkDatatable> TalkDatatables { get; set; } = new List<TalkDatatable>();

    public virtual ICollection<TalkPersontable> TalkPersontables { get; set; } = new List<TalkPersontable>();
}
