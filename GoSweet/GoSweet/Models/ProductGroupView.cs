using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class ProductGroupView
{
    public int Expr1 { get; set; }

    public int FNumber { get; set; }

    public int Expr2 { get; set; }

    public string PName { get; set; } = null!;

    public string? PSpec { get; set; }

    public string PCategory { get; set; } = null!;

    public int PPrice { get; set; }

    public string? PDescribe { get; set; }

    public string? PSavedate { get; set; }

    public string? PSaveway { get; set; }

    public int PInventory { get; set; }

    public int? PShip { get; set; }

    public int? PPayment { get; set; }

    public int PPicnumber { get; set; }

    public string PUrl { get; set; } = null!;

    public DateTime GStart { get; set; }

    public DateTime GEnd { get; set; }

    public int GMaxpeople { get; set; }

    public int GPrice { get; set; }

    public int ONumber { get; set; }

    public int? PNumber { get; set; }

    public double? OCscore { get; set; }

    public double? OFscore { get; set; }
}
