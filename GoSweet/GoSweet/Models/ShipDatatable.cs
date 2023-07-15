using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class ShipDatatable
{
    public int ShipNumber { get; set; }

    public string ShipName { get; set; } = null!;

    public virtual ICollection<OrderDatatable> OrderDatatables { get; set; } = new List<OrderDatatable>();

    public virtual ICollection<ProductDatatable> PNumbers { get; set; } = new List<ProductDatatable>();
}
