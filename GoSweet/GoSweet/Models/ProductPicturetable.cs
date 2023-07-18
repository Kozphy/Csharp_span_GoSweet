using System;
using System.Collections.Generic;

namespace GoSweet.Models;

public partial class ProductPicturetable
{
    public int PSort { get; set; }

    public int PPicnumber { get; set; }

    public int PNumber { get; set; }

    public string PUrl { get; set; } = null!;

    public virtual ProductDatatable PNumberNavigation { get; set; } = null!;
}
