using Healthcare.Infrastructure.Identity;
using Healthcare.Web.ViewModels.Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Web.Areas.Doctor.Controllers;

[Area("Doctor")]
[Authorize(Roles = ApplicationRoles.Doctor)]
public class DashboardController : Controller
{
    [HttpGet]
    public IActionResult Index() => View(new DoctorDashboardViewModel
    {
        FullName = User.Identity?.Name ?? "Doctor",
        IsApproved = false,
        MedicalSyndicateNumber = "Pending"
    });
}
