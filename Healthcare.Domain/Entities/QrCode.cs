using Healthcare.Domain.Common;

namespace Healthcare.Domain.Entities;

public class QrCode : BaseEntity
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;
    public string Token { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
