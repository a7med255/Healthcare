using System.ComponentModel.DataAnnotations;

namespace Healthcare.Web.ViewModels.Account;

public class RegisterDoctorViewModel : RegisterPatientViewModel
{
    [Required, StringLength(100)]
    [Display(Name = "Medical Syndicate Number")]
    public string MedicalSyndicateNumber { get; set; } = string.Empty;
}
