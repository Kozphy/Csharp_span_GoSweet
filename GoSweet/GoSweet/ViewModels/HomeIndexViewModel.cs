using GoSweet.Models;

namespace GoSweet.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductRankDataViewModel> productRankDatas { get; set; }
        public IEnumerable<ProductGroupBuyData> productGroupBuyDatas { get; set; }
    }

    public class ProductRankDataViewModel
    {
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public int ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductBuyNumber { get; set; }
    }

    public class ProductGroupBuyData
    {
        public string? ProductName { get; set; }
    } 

}
