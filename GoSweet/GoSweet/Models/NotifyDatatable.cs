
﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GoSweet.Models
{
    public partial class NotifyDatatable
    {
        public int NNumber { get; set; }
        public int? CNumber { get; set; }
        public int? FNumber { get; set; }
        public int ONumber { get; set; }
        public string OStatus { get; set; }
        public bool? NRead { get; set; }

        public virtual CustomerAccounttable CNumberNavigation { get; set; }
        public virtual FirmAccounttable FNumberNavigation { get; set; }
        public virtual OrderDatatable ONumberNavigation { get; set; }
    }
}

