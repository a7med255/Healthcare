using Healthcare.Domain.Common;

namespace Healthcare.Domain.Entities;

public class MedicalRecord : BaseEntity
{
    public Guid PatientProfileId { get; set; }
    public PatientProfile PatientProfile { get; set; } = null!;
    public Guid DoctorProfileId { get; set; }
    public DoctorProfile DoctorProfile { get; set; } = null!;
    public string Diagnosis { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public DateTime VisitDateUtc { get; set; }
    public string MedicalSyndicateNumber { get; set; } = string.Empty;
    public ICollection<MedicalImage> PrescriptionImages { get; set; } = new List<MedicalImage>();
}
