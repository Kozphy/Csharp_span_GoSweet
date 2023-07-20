using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class OrderDatatable
{
    public int ONumber { get; set; }

    public DateTime OStart { get; set; }

    public DateTime? OEnd { get; set; }

    public int CNumber { get; set; }

    public int FNumber { get; set; }

    public bool OType { get; set; }

    public int? MNumber { get; set; }

    public int PNumber { get; set; }

    public int OBuynumber { get; set; }

    public int OPrice { get; set; }

    public string OStatus { get; set; } = null!;

    public string OShipstatus { get; set; } = null!;

    public int? OShip { get; set; }

    public string? OPlace { get; set; }

    public int? OPayment { get; set; }

    public virtual CustomerAccounttable CNumberNavigation { get; set; } = null!;

    public virtual FirmAccounttable FNumberNavigation { get; set; } = null!;

    public virtual MemberMembertable? MNumberNavigation { get; set; }

    public virtual ICollection<NotifyDatatable> NotifyDatatables { get; set; } = new List<NotifyDatatable>();

    public virtual ICollection<OrderAssesstable> OrderAssesstables { get; set; } = new List<OrderAssesstable>();

    public virtual ProductDatatable PNumberNavigation { get; set; } = null!;
}
