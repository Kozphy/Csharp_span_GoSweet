﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GoSweet.Models
{
    public partial class PaymentDatatable
    {
        public PaymentDatatable()
        {
            OrderDatatables = new HashSet<OrderDatatable>();
            PNumbers = new HashSet<ProductDatatable>();
        }

        public int PaymentNumber { get; set; }
        public string PaymentName { get; set; }

        public virtual ICollection<OrderDatatable> OrderDatatables { get; set; }

        public virtual ICollection<ProductDatatable> PNumbers { get; set; }
    }
}