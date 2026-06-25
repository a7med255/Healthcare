using System.ComponentModel.DataAnnotations;

namespace Healthcare.Web.ViewModels.Doctor;

public class ScanPatientViewModel
{
    [Required]
    [Display(Name = "Patient QR Code Token")]
    public string QrCodeToken { get; set; } = string.Empty;

    [Required, RegularExpression("^[0-9]{4}$", ErrorMessage = "PIN must be exactly 4 digits.")]
    [Display(Name = "Patient PIN")]
    public string PatientPin { get; set; } = string.Empty;
}
