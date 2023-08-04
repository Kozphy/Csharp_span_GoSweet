using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoSweet.Models.ViewModels
{
    public class BaseUser
    {
        public const int PasswordMinLength = 8;
        public const string RegEmail = @"[a-z0-9]+@[a-z]+\.[a-z]{2,3}";
        public const string RegEmailErrorMessage = "Please enter a valid email address";
    }

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

    public class CustomerLoginVm : BaseUser
    {
        [DisplayName("Email")]
        [RegularExpression(RegEmail, ErrorMessage = RegEmailErrorMessage)]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        [Required(ErrorMessage ="帳號必填")]
        public string? CAccount { get; set; }

        [DisplayName("密碼")]
        [MinLength(PasswordMinLength, ErrorMessage="密碼必須大於 8 碼")]
        [Required(ErrorMessage = "密碼必填")]
        public string? CPassword { get; set; }
    }

    public class CustomerAccountVm : BaseUser
    {
        [DisplayName("帳號名稱")]
        [Required(ErrorMessage ="帳號名稱必填")]
        public string? CNickname { get; set; }
        public int CNumber { get; set; }


        [DisplayName("Email")]
        [RegularExpression(RegEmail, ErrorMessage = RegEmailErrorMessage)]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        [Required(ErrorMessage ="帳號必填")]
        public string? CAccount { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [MinLength(PasswordMinLength, ErrorMessage="密碼必須大於 8 碼")]
        public string? CPassword { get; set; }

        [DisplayName("確認密碼")]
        [Required(ErrorMessage = "確認密碼必填")]
        [MinLength(PasswordMinLength, ErrorMessage="密碼必須大於 8 碼")]
        public string? CPasswordCheck { get; set; }
        public bool CMailpass { get; set; }
    }
    public class FirmAccountLoginVm : BaseUser
    {
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        [Required(ErrorMessage ="帳號必填")]
        public string? FAccount { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [MinLength(PasswordMinLength, ErrorMessage="密碼必須大於 8 碼")]
        public string? FPassword { get; set; }
    }

    public class FirmAccountVm: BaseUser
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
        [MinLength(PasswordMinLength, ErrorMessage="密碼必須大於 8 碼")]
        public string? FPassword { get; set; }


        [DisplayName("確認密碼")]
        [Required(ErrorMessage = "確認密碼必填")]
        [MinLength(PasswordMinLength, ErrorMessage="密碼必須大於 8 碼")]
        public string? FPasswordCheck { get; set; }
        public bool FMailpass { get; set; }
    }

    public class ResetPasswordVm : BaseUser
    {
        public string? EmailAddress { get; set; }

        [DisplayName("新密碼")]
        [Required(ErrorMessage = "newPassword required")]
        [MinLength(PasswordMinLength, ErrorMessage="密碼必須大於 8 碼")]
        public string? NewPassword { get; set; }

        [DisplayName("確認新密碼")]
        [Required(ErrorMessage = "check newPassword required")]
        [MinLength(PasswordMinLength, ErrorMessage="密碼必須大於 8 碼")]
        public string? CheckNewPassword { get; set; }
    }

}
