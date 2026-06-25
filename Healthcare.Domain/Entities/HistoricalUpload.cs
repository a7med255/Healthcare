using Healthcare.Domain.Common;

namespace Healthcare.Domain.Entities;

public class HistoricalUpload : BaseEntity
{
    public Guid PatientProfileId { get; set; }
    public PatientProfile PatientProfile { get; set; } = null!;
    public string FilePath { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long FileSizeBytes { get; set; }
}
