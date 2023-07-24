using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoSweet.Models.ViewModels
{
    public class AccountVm
    {
       public CustomerAccountVm? customerAccountVm { get; set; }
       public FirmAccountVm? firmAccountVm { get; set; }
    }

    public class CustomerAccountVm
    {
        [DisplayName("帳號名稱")]
        [BindProperty(Name = "AccountName")]
        public string? CNickname { get; set; }
        public int CNumber { get; set; }


        [DisplayName("Email")]
        [Required(ErrorMessage ="帳號必填")]
        [BindProperty(Name = "UserEmail")]
        public string? CAccount { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [BindProperty(Name = "UserPassword")]
        public string? CPassword { get; set; }
        public bool CMailpass { get; set; }
    }

    public class FirmAccountVm
    {
        public int FNumber { get; set; }

        [DisplayName("帳號名稱")]
        [BindProperty(Name = "AccountName")]
        public string? FNickname { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage ="帳號必填")]
        [BindProperty(Name = "UserEmail")]
        public string? FAccount { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [BindProperty(Name = "UserPassword")]
        public string? FPassword { get; set; }
        public bool FMailpass { get; set; }

    }

}
