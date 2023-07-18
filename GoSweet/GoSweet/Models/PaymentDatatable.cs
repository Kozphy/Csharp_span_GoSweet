using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class PaymentDatatable
{
    public int PaymentNumber { get; set; }

    public string PaymentName { get; set; } = null!;

    public virtual ICollection<OrderDatatable> OrderDatatables { get; set; } = new List<OrderDatatable>();

    public virtual ICollection<ProductDatatable> PNumbers { get; set; } = new List<ProductDatatable>();
}
