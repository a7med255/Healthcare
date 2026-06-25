using Healthcare.Infrastructure.Identity;
using Healthcare.Web.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Web.Areas.Patient.Controllers;

[Area("Patient")]
[Authorize(Roles = ApplicationRoles.Patient)]
public class DashboardController : Controller
{
    [HttpGet]
    public IActionResult Index() => View(new PatientDashboardViewModel
    {
        FullName = User.Identity?.Name ?? "Patient",
        RecentRecords = []
    });
}
