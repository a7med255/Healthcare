namespace Healthcare.Web.ViewModels.Patient;

public class MedicalRecordSummaryViewModel
{
    public Guid Id { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public DateTime VisitDateUtc { get; set; }
    public string MedicalSyndicateNumber { get; set; } = string.Empty;
    public int PrescriptionImageCount { get; set; }
}
