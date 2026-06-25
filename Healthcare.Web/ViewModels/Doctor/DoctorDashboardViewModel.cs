namespace Healthcare.Web.ViewModels.Doctor;

public class DoctorDashboardViewModel
{
    public string FullName { get; set; } = string.Empty;
    public bool IsApproved { get; set; }
    public string MedicalSyndicateNumber { get; set; } = string.Empty;
    public int RecordsCreatedThisMonth { get; set; }
}
