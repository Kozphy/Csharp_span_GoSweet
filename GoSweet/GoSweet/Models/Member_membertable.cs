﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GoSweet.Models
{
    public partial class Member_membertable
    {
        public Member_membertable()
        {
            Order_datatables = new HashSet<Order_datatable>();
        }

        public int m_number { get; set; }
        public int g_number { get; set; }
        public int p_number { get; set; }
        public int g_maxpeople { get; set; }
        public int m_nowpeople { get; set; }
        public bool m_status { get; set; }

        public virtual Group_datatable g_numberNavigation { get; set; }
        public virtual Product_datatable p_numberNavigation { get; set; }
        public virtual ICollection<Order_datatable> Order_datatables { get; set; }
    }
}