using Healthcare.Domain.Common;

namespace Healthcare.Domain.Entities;

public class DoctorProfile : BaseEntity
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;
    public string MedicalSyndicateNumber { get; set; } = string.Empty;
    public bool IsApproved { get; set; }
    public DoctorApprovalRequest? ApprovalRequest { get; set; }
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}
