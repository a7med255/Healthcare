using Healthcare.Infrastructure.Identity;
using Healthcare.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = ApplicationRoles.Admin)]
public class DoctorApprovalsController : Controller
{
    [HttpGet]
    public IActionResult Index() => View(Array.Empty<DoctorApprovalRequestViewModel>());

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Approve(Guid id)
    {
        TempData["StatusMessage"] = $"Approval endpoint received request {id}.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Reject(Guid id) => View(new RejectDoctorViewModel { RequestId = id });

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Reject(RejectDoctorViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        TempData["StatusMessage"] = "Rejection endpoint is ready for doctor approval service integration.";
        return RedirectToAction(nameof(Index));
    }
}
