﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GoSweet.Models
{
    public partial class Product_picturetable
    {
        public int p_picnumber { get; set; }
        public int p_number { get; set; }
        public string p_url { get; set; }

        public virtual Product_datatable p_numberNavigation { get; set; }
    }
}