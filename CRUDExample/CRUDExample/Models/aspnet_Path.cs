﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CRUDExample.Models
{
    public partial class aspnet_Path
    {
        public aspnet_Path()
        {
            aspnet_PersonalizationPerUsers = new HashSet<aspnet_PersonalizationPerUser>();
        }

        public Guid ApplicationId { get; set; }
        public Guid PathId { get; set; }
        public string Path { get; set; }
        public string LoweredPath { get; set; }

        public virtual aspnet_Application Application { get; set; }
        public virtual aspnet_PersonalizationAllUser aspnet_PersonalizationAllUser { get; set; }
        public virtual ICollection<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUsers { get; set; }
    }
}