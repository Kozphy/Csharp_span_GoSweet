﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GoSweet.Models
{
    public partial class MemberMembertable
    {
        public MemberMembertable()
        {
            OrderDatatables = new HashSet<OrderDatatable>();
        }

        public int MNumber { get; set; }
        public int GNumber { get; set; }
        public int GMaxpeople { get; set; }
        public int MNowpeople { get; set; }
        public bool MStatus { get; set; }

        public virtual GroupDatatable GNumberNavigation { get; set; }
        public virtual ICollection<OrderDatatable> OrderDatatables { get; set; }
    }
}