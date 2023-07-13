﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoSweet.Models
{
    public partial class Customer_accounttable
    {
        public Customer_accounttable()
        {
            Notify_datatables = new HashSet<Notify_datatable>();
            Order_datatables = new HashSet<Order_datatable>();
            Talk_datatables = new HashSet<Talk_datatable>();
            Talk_persontables = new HashSet<Talk_persontable>();
        }

        [BindProperty(Name ="AccountName")]
        public string c_nickname { get; set; }
        public int c_number { get; set; }
        [EmailAddress]
        [BindProperty(Name = "UserEmail")]
        public string c_account { get; set; }
        [BindProperty(Name = "UserPassword")]
        public string c_password { get; set; }
        public bool c_mailpass { get; set; }


        public virtual ICollection<Notify_datatable> Notify_datatables { get; set; }
        public virtual ICollection<Order_datatable> Order_datatables { get; set; }
        public virtual ICollection<Talk_datatable> Talk_datatables { get; set; }
        public virtual ICollection<Talk_persontable> Talk_persontables { get; set; }
    }
}