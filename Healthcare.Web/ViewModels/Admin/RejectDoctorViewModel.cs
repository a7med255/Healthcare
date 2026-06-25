using System.ComponentModel.DataAnnotations;

namespace Healthcare.Web.ViewModels.Admin;

public class RejectDoctorViewModel
{
    [Required]
    public Guid RequestId { get; set; }

    [Required, StringLength(500)]
    [Display(Name = "Rejection Reason")]
    public string Reason { get; set; } = string.Empty;
}
