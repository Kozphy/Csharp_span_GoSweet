namespace GoSweet.Models.ViewModels
{
    public class FirmHomepageModel
    {
        //廠商圖片位置-尚未處理，名稱也可以考慮
        public string? PicturePath { get; set; }

        //當月訂單數
        public string? ThisMonthOrdersTotal { get; set; }

        //當月出貨數
        public string? ThisMonthShippedTotal { get; set; }

        //當月未出貨數
        public string? ThisMonthunShippedTotal { get; set; }

        //當月總收入
        public string? ThisMonthReveune { get; set; }

        //上月訂單數
        public string? LastMonthOrdersTotal { get; set; }

        //上月出貨數
        public string? LastMonthShippedTotal { get; set; }

        //上月未出貨數
        public string? LastMonthunShippedTotal { get; set; }

        //上月總收入
        public string? LastMonthReveune { get; set; }

        //待出貨清單
        public List<WaitingLists>? WaitingList { get; set; }

        //熱門評論
        public List<RecentlyComment>? RecentlyComments { get; set; }

        //熱門品項
        public List<HotSales>? HotSale { get; set; }

        public IEnumerable<FirmBellDropDownVm>? FirmBellDropDownDatas { get; set; }
    }

    public class WaitingLists
    {
        private string _WaitingDateFormat = "";
        public string? OrderDate
        {
            get { return _WaitingDateFormat; }
            set { _WaitingDateFormat = Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        public int? OrderID { get; set; }

        public string? Products { get; set; }
    }

    public class RecentlyComment
    {
        private string _CommentDateFormat = "";
        public string? CommentDate
        {
            get { return _CommentDateFormat; }
            set { _CommentDateFormat = Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        public string? Content { get; set; }
    }

    public class HotSales
    {
        public string? ProductName { get; set; }

        public int Quentity { get; set; }
    }

    //Json用類型
    public class ratingvalue {

        public double? ratingScore { get; set; }

        public int? ratingQuentity { get; set; }
    }
}
