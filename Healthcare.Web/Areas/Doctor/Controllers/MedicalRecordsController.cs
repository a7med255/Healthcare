using Healthcare.Infrastructure.Identity;
using Healthcare.Web.ViewModels.Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Web.Areas.Doctor.Controllers;

[Area("Doctor")]
[Authorize(Roles = ApplicationRoles.Doctor)]
public class MedicalRecordsController : Controller
{
    [HttpGet]
    public IActionResult Create(Guid patientProfileId) => View(new CreateMedicalRecordViewModel { PatientProfileId = patientProfileId });

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(CreateMedicalRecordViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        TempData["StatusMessage"] = "Medical record creation endpoint is ready for the medical record service implementation.";
        return RedirectToAction("History", "Patients");
    }
}
