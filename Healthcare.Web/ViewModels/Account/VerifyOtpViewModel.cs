using System.ComponentModel.DataAnnotations;

namespace Healthcare.Web.ViewModels.Account;

public class VerifyOtpViewModel
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, RegularExpression("^[0-9]{6}$", ErrorMessage = "OTP must be exactly 6 digits.")]
    [Display(Name = "Email OTP")]
    public string OtpCode { get; set; } = string.Empty;
}
