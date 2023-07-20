﻿using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class OrderAssesstable
{
    public int ONumber { get; set; }

    public int PNumber { get; set; }

    public double? OCscore { get; set; }

    public string? OCcomment { get; set; }

    public double? OFscore { get; set; }

    public string? OFcomment { get; set; }

    public virtual OrderDatatable ONumberNavigation { get; set; } = null!;

    public virtual ProductDatatable PNumberNavigation { get; set; } = null!;
}
