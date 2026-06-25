using Healthcare.Domain.Common;
using Healthcare.Domain.Enums;

namespace Healthcare.Domain.Entities;

public class DoctorApprovalRequest : BaseEntity
{
    public Guid DoctorProfileId { get; set; }
    public DoctorProfile DoctorProfile { get; set; } = null!;
    public string MedicalSyndicateCardPath { get; set; } = string.Empty;
    public DoctorApprovalStatus Status { get; set; } = DoctorApprovalStatus.Pending;
    public Guid? ReviewedByAdminId { get; set; }
    public ApplicationUser? ReviewedByAdmin { get; set; }
    public DateTime? ReviewedAtUtc { get; set; }
    public string? RejectionReason { get; set; }
}
