using Healthcare.Infrastructure.Identity;
using Healthcare.Web.ViewModels.Doctor;
using Healthcare.Web.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Web.Areas.Doctor.Controllers;

[Area("Doctor")]
[Authorize(Roles = ApplicationRoles.Doctor)]
public class PatientsController : Controller
{
    [HttpGet]
    public IActionResult Scan() => View(new ScanPatientViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Scan(ScanPatientViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        return RedirectToAction(nameof(History));
    }

    [HttpGet]
    public IActionResult History() => View(Array.Empty<MedicalRecordSummaryViewModel>());
}
