﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GoSweet.Models
{
    public partial class CustomerAccounttable
    {
        public CustomerAccounttable()
        {
            NotifyDatatables = new HashSet<NotifyDatatable>();
            OrderDatatables = new HashSet<OrderDatatable>();
            TalkDatatables = new HashSet<TalkDatatable>();
            TalkMembertables = new HashSet<TalkMembertable>();
            TalkPersontables = new HashSet<TalkPersontable>();
        }


        public string CNickname { get; set; }
        public int CNumber { get; set; }

        public string CAccount { get; set; }

        public string CPassword { get; set; }
        public bool CMailpass { get; set; }

        public virtual ICollection<NotifyDatatable> NotifyDatatables { get; set; }
        public virtual ICollection<OrderDatatable> OrderDatatables { get; set; }
        public virtual ICollection<TalkDatatable> TalkDatatables { get; set; }
        public virtual ICollection<TalkMembertable> TalkMembertables { get; set; }
        public virtual ICollection<TalkPersontable> TalkPersontables { get; set; }
    }
}