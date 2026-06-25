namespace Healthcare.Web.ViewModels.Patient;

public class PatientDashboardViewModel
{
    public string FullName { get; set; } = string.Empty;
    public string? ActiveQrCodeImagePath { get; set; }
    public IReadOnlyList<MedicalRecordSummaryViewModel> RecentRecords { get; set; } = [];
}
