using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoSweet.Models.ViewModels
{
    public class AccountVm
    {
       public CustomerAccountVm? customerAccountVm { get; set; }
       public FirmAccountVm? firmAccountVm { get; set; }

        public AccountVm(CustomerAccountVm? customerAccountVm, FirmAccountVm? firmAccountVm)
        {
            this.customerAccountVm = customerAccountVm;
            this.firmAccountVm = firmAccountVm;
        }
    }

    public class CustomerLoginVm
    {
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        [Required(ErrorMessage ="帳號必填")]
        public string? CAccount { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必填")]
        public string? CPassword { get; set; }
    }

    public class CustomerAccountVm
    {
        [DisplayName("帳號名稱")]
        [Required(ErrorMessage ="帳號名稱必填")]
        public string? CNickname { get; set; }
        public int CNumber { get; set; }


        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        [Required(ErrorMessage ="帳號必填")]
        public string? CAccount { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必填")]
        public string? CPassword { get; set; }

        [DisplayName("確認密碼")]
        [Required(ErrorMessage = "確認密碼必填")]
        public string? CPasswordCheck { get; set; }
        public bool CMailpass { get; set; }
    }
    public class FirmAccountLoginVm
    {
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        [Required(ErrorMessage ="帳號必填")]
        public string? FAccount { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必填")]
        public string? FPassword { get; set; }
    }

    public class FirmAccountVm
    {
        public int FNumber { get; set; }

        [DisplayName("帳號名稱")]
        [Required(ErrorMessage ="帳號名稱必填")]
        public string? FNickname { get; set; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        [Required(ErrorMessage ="帳號必填")]
        public string? FAccount { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必填")]
        public string? FPassword { get; set; }


        [DisplayName("確認密碼")]
        [Required(ErrorMessage = "確認密碼必填")]
        public string? FPasswordCheck { get; set; }
        public bool FMailpass { get; set; }
    }

    public class ResetPasswordVm
    {
        public string? EmailAddress { get; set; }

        [DisplayName("新密碼")]
        [Required(ErrorMessage = "newPassword required")]
        public string? NewPassword { get; set; }

        [DisplayName("確認新密碼")]
        [Required(ErrorMessage = "check newPassword required")]
        public string? CheckNewPassword { get; set; }
    }

}
