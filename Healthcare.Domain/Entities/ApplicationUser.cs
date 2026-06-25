using Healthcare.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Healthcare.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public string PinHash { get; set; } = string.Empty;
    public bool IsIdentityVerified { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public PatientProfile? PatientProfile { get; set; }
    public DoctorProfile? DoctorProfile { get; set; }
    public ICollection<OtpCode> OtpCodes { get; set; } = new List<OtpCode>();
    public ICollection<QrCode> QrCodes { get; set; } = new List<QrCode>();
}
