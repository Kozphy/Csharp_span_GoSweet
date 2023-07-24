namespace GoSweet.Models.ViewModels
{
    public class FirmRevenueModels
    {
    }

    //Json用類別
    public class RevenueSearch
    {

        private string _RevenueSearchDate = "";
        private string _RevenueTotal = "";
        private string _OrderType = "";

        public string orderDate
        {
            set { _RevenueSearchDate = Convert.ToDateTime(value).ToString("yyyy-MM-dd"); }
            get { return _RevenueSearchDate; }
        }

        public string? name { get; set; }

        public string? orderType { get; set; }

        public string? shipState { get; set; }

        public string? categories { get; set; }

        public int id { get; set; }

        public int quentity { get; set; }

        public decimal price { get; set; }

        public decimal total { get; set; }
    }
}
