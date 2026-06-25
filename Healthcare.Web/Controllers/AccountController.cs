using Healthcare.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Web.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    [HttpGet]
    public IActionResult RegisterPatient() => View(new RegisterPatientViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult RegisterPatient(RegisterPatientViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        TempData["StatusMessage"] = "Patient registration submitted. Phase 2 services will send the email OTP.";
        return RedirectToAction(nameof(VerifyOtp), new { email = model.Email });
    }

    [HttpGet]
    public IActionResult RegisterDoctor() => View(new RegisterDoctorViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult RegisterDoctor(RegisterDoctorViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        TempData["StatusMessage"] = "Doctor registration submitted. Upload and approval workflow continues in the doctor area.";
        return RedirectToAction(nameof(VerifyOtp), new { email = model.Email });
    }

    [HttpGet]
    public IActionResult VerifyOtp(string? email) => View(new VerifyOtpViewModel { Email = email ?? string.Empty });

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult VerifyOtp(VerifyOtpViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        TempData["StatusMessage"] = "OTP verification endpoint is ready for the email verification service implementation.";
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null) => View(new LoginViewModel { ReturnUrl = returnUrl });

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        TempData["StatusMessage"] = "Login service integration will be completed in the authentication module.";
        return LocalRedirect(string.IsNullOrWhiteSpace(model.ReturnUrl) ? Url.Action("Index", "Home")! : model.ReturnUrl);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        TempData["StatusMessage"] = "Logout service integration will be completed in the authentication module.";
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult AccessDenied() => View();
}
