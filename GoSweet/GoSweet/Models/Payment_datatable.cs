﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GoSweet.Models
{
    public partial class Payment_datatable
    {
        public Payment_datatable()
        {
            p_numbers = new HashSet<Product_datatable>();
        }

        public int Payment_number { get; set; }
        public string Payment_name { get; set; }

        public virtual ICollection<Product_datatable> p_numbers { get; set; }
    }
}