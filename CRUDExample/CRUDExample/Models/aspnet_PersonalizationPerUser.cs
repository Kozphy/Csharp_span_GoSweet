﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CRUDExample.Models
{
    public partial class aspnet_PersonalizationPerUser
    {
        public Guid Id { get; set; }
        public Guid? PathId { get; set; }
        public Guid? UserId { get; set; }
        public byte[] PageSettings { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public virtual aspnet_Path Path { get; set; }
        public virtual aspnet_User User { get; set; }
    }
}