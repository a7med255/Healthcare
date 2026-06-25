using Healthcare.Infrastructure.Identity;
using Healthcare.Web.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Web.Areas.Patient.Controllers;

[Area("Patient")]
[Authorize(Roles = ApplicationRoles.Patient)]
public class MedicalHistoryController : Controller
{
    [HttpGet]
    public IActionResult Access() => View(new AccessMedicalHistoryViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Access(AccessMedicalHistoryViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Index() => View(Array.Empty<MedicalRecordSummaryViewModel>());

    [HttpGet]
    public IActionResult ExportPdf()
    {
        TempData["StatusMessage"] = "PDF export endpoint is ready for QuestPDF service integration.";
        return RedirectToAction(nameof(Index));
    }
}
