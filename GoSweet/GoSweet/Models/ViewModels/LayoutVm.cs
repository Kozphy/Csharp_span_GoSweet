namespace GoSweet.Models.ViewModels
{

    public class CustomerBellDropDownVm { 
        //public IEnumerable<InotifyMessage>? notifyMessage { get; set; }
        //public IEnumerable<notifyMessageAlreadySendVm>? notifyMessageAlreadySendDatas { get; set; }
         public int? GroupNumber { get; set; }
         public int? OrderNumber { get; set; }
         public string? ProductName { get; set; }
         public string? OrderStatus { get; set; }
    }

    public class FirmBellDropDownVm { 
         public int? OrderNumber { get; set; }
         public string? ProductName { get; set; }
         public string? OrderStatus { get; set; }
    }



    //public class notifyMessageAlreadyGroupVm{
    //    public int GroupNumber { get; set; }
    //    public string? ProductName { get; set; }
    //    public string? OrderStatus { get; set; }
        
    //}

    //public class notifyMessageAlreadySendVm{ 

    //    public int OrderNumber { get; set; }
    //    //public string? Account { get; set; }
    //    public string? ProductName { get; set; }
    //    public string? OrderStatus { get; set; }
    //}

}
