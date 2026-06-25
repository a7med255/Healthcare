using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Healthcare.Web.ViewModels.Doctor;

public class CreateMedicalRecordViewModel
{
    [Required]
    public Guid PatientProfileId { get; set; }

    [Required, StringLength(4000)]
    public string Diagnosis { get; set; } = string.Empty;

    [Display(Name = "Prescription Images")]
    public IReadOnlyList<IFormFile> PrescriptionImages { get; set; } = [];
}
