using Healthcare.Domain.Common;

namespace Healthcare.Domain.Entities;

public class PatientProfile : BaseEntity
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    public ICollection<HistoricalUpload> HistoricalUploads { get; set; } = new List<HistoricalUpload>();
}
