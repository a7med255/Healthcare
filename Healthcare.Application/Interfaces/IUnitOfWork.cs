using Healthcare.Domain.Entities;

namespace Healthcare.Application.Interfaces;

public interface IUnitOfWork
{
    IRepository<PatientProfile> Patients { get; }
    IRepository<DoctorProfile> Doctors { get; }
    IRepository<OtpCode> OtpCodes { get; }
    IRepository<DoctorApprovalRequest> DoctorApprovalRequests { get; }
    IRepository<QrCode> QrCodes { get; }
    IRepository<MedicalRecord> MedicalRecords { get; }
    IRepository<MedicalImage> MedicalImages { get; }
    IRepository<HistoricalUpload> HistoricalUploads { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
