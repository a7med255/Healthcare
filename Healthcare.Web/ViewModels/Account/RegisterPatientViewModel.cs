using System.ComponentModel.DataAnnotations;

namespace Healthcare.Web.ViewModels.Account;

public class RegisterPatientViewModel
{
    [Required, StringLength(200)]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required, StringLength(50)]
    [Display(Name = "National ID")]
    public string NationalId { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required, DataType(DataType.Password), MinLength(8)]
    public string Password { get; set; } = string.Empty;

    [Required, DataType(DataType.Password), Compare(nameof(Password))]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required, RegularExpression("^[0-9]{4}$", ErrorMessage = "PIN must be exactly 4 digits.")]
    [Display(Name = "4-digit PIN")]
    public string Pin { get; set; } = string.Empty;
}
