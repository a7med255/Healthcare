using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using Healthcare.Infrastructure.Data;
using Healthcare.Infrastructure.Repositories;

namespace Healthcare.Infrastructure.UnitOfWork;

public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    public IRepository<PatientProfile> Patients { get; } = new Repository<PatientProfile>(dbContext);
    public IRepository<DoctorProfile> Doctors { get; } = new Repository<DoctorProfile>(dbContext);
    public IRepository<OtpCode> OtpCodes { get; } = new Repository<OtpCode>(dbContext);
    public IRepository<DoctorApprovalRequest> DoctorApprovalRequests { get; } = new Repository<DoctorApprovalRequest>(dbContext);
    public IRepository<QrCode> QrCodes { get; } = new Repository<QrCode>(dbContext);
    public IRepository<MedicalRecord> MedicalRecords { get; } = new Repository<MedicalRecord>(dbContext);
    public IRepository<MedicalImage> MedicalImages { get; } = new Repository<MedicalImage>(dbContext);
    public IRepository<HistoricalUpload> HistoricalUploads { get; } = new Repository<HistoricalUpload>(dbContext);
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => dbContext.SaveChangesAsync(cancellationToken);
}
