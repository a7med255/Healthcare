using Healthcare.Infrastructure.Identity;
using Healthcare.Web.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Web.Areas.Patient.Controllers;

[Area("Patient")]
[Authorize(Roles = ApplicationRoles.Patient)]
public class HistoricalUploadController : Controller
{
    [HttpGet]
    public IActionResult Create() => View(new HistoricalUploadViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(HistoricalUploadViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        TempData["StatusMessage"] = "Historical uploads endpoint is ready for storage service integration.";
        return RedirectToAction("Index", "Dashboard");
    }
}
