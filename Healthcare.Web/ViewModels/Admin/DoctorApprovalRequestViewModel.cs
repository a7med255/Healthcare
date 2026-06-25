namespace Healthcare.Web.ViewModels.Admin;

public class DoctorApprovalRequestViewModel
{
    public Guid Id { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string MedicalSyndicateNumber { get; set; } = string.Empty;
    public string MedicalSyndicateCardPath { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime SubmittedAtUtc { get; set; }
}
