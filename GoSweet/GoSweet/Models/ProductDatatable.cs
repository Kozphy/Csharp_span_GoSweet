using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace GoSweet.Models;

public partial class ProductDatatable
{
    public int FNumber { get; set; }

    public int PNumber { get; set; }

    [DisplayName("商品名稱")]
    public string PName { get; set; } = null!;

    [DisplayName("商品規格")]
    public string? PSpec { get; set; }

    [DisplayName("商品種類")]
    public string PCategory { get; set; } = null!;

    [DisplayName("商品價格")]
    public int PPrice { get; set; }

    [DisplayName("商品描述")]
    public string? PDescribe { get; set; }

    [DisplayName("保存期限")]
    public string? PSavedate { get; set; }

    [DisplayName("保存方式")]
    public string? PSaveway { get; set; }

    [DisplayName("商品庫存")]
    public int PInventory { get; set; }

    public int? PShip { get; set; }

    public int? PPayment { get; set; }

    public virtual FirmAccounttable FNumberNavigation { get; set; } = null!;

    public virtual ICollection<GroupDatatable> GroupDatatables { get; set; } = new List<GroupDatatable>();

    public virtual ICollection<OrderAssesstable> OrderAssesstables { get; set; } = new List<OrderAssesstable>();

    public virtual ICollection<OrderDatatable> OrderDatatables { get; set; } = new List<OrderDatatable>();

    public virtual ICollection<ProductPicturetable> ProductPicturetables { get; set; } = new List<ProductPicturetable>();

    public virtual ICollection<PaymentDatatable> PaymentNumbers { get; set; } = new List<PaymentDatatable>();

    public virtual ICollection<ShipDatatable> ShipNumbers { get; set; } = new List<ShipDatatable>();
}
