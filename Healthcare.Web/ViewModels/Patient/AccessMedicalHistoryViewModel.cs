using System.ComponentModel.DataAnnotations;

namespace Healthcare.Web.ViewModels.Patient;

public class AccessMedicalHistoryViewModel
{
    [Required]
    [Display(Name = "QR Code Token")]
    public string QrCodeToken { get; set; } = string.Empty;

    [Required, RegularExpression("^[0-9]{4}$", ErrorMessage = "PIN must be exactly 4 digits.")]
    public string Pin { get; set; } = string.Empty;
}
