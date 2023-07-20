
﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GoSweet.Models
{
    public partial class ProductDatatable
    {
        public ProductDatatable()
        {
            GroupDatatables = new HashSet<GroupDatatable>();
            OrderDatatables = new HashSet<OrderDatatable>();
            ProductPicturetables = new HashSet<ProductPicturetable>();
            PaymentNumbers = new HashSet<PaymentDatatable>();
            ShipNumbers = new HashSet<ShipDatatable>();
        }

        public int FNumber { get; set; }
        public int PNumber { get; set; }
        public string PName { get; set; }
        public string PSpec { get; set; }
        public string PCategory { get; set; }
        public int PPrice { get; set; }
        public string PDescribe { get; set; }
        public string PSavedate { get; set; }
        public string PSaveway { get; set; }
        public int PInventory { get; set; }
        public int? PShip { get; set; }
        public int? PPayment { get; set; }

        public virtual FirmAccounttable FNumberNavigation { get; set; }
        public virtual ICollection<GroupDatatable> GroupDatatables { get; set; }
        public virtual ICollection<OrderDatatable> OrderDatatables { get; set; }
        public virtual ICollection<ProductPicturetable> ProductPicturetables { get; set; }

        public virtual ICollection<PaymentDatatable> PaymentNumbers { get; set; }
        public virtual ICollection<ShipDatatable> ShipNumbers { get; set; }
    }
}

