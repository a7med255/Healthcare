using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Healthcare.Web.ViewModels.Patient;

public class HistoricalUploadViewModel
{
    [Required]
    [Display(Name = "Medical Images")]
    public IReadOnlyList<IFormFile> Files { get; set; } = [];
}
