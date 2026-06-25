using Healthcare.Domain.Common;
using Healthcare.Domain.Enums;

namespace Healthcare.Domain.Entities;

public class OtpCode : BaseEntity
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;
    public string CodeHash { get; set; } = string.Empty;
    public OtpPurpose Purpose { get; set; }
    public DateTime ExpiresAtUtc { get; set; }
    public DateTime? ConsumedAtUtc { get; set; }
    public bool IsConsumed => ConsumedAtUtc.HasValue;
}
