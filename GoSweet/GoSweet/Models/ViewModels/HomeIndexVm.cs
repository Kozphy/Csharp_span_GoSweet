using GoSweet.Models;

namespace GoSweet.Models.ViewModels
{
    public class HomeIndexVm
    {
        public IEnumerable<CategoryViewModel>? CategoryDatas { get; set; }
        public IEnumerable<ProductRankDataViewModel>? ProductRankDatas { get; set; }
        public IEnumerable<ProductGroupBuyData>? ProductGroupBuyDatas { get; set; }

    }

    public class CategoryViewModel
    {
        public string? Category { get; set; }
    }

    public class ProductRankDataViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductPicture { get; set; }
        public int ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductTotalBuyNumber { get; set; }
    }

    public class ProductGroupBuyData
    {
        public string? ProductName { get; set; }
        public string? ProductPicture { get; set; }
        public string? ProductDescription { get; set; }
        public int GroupMaxPeople { get; set; }
        public int GroupNowPeople { get; set; }
        public double GroupPeoplePercent { get; set; }
        public DateTime GroupEndDate { get; set; }
        public int GroupRemainDate { get; set; }
    }

}
