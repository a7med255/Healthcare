using Healthcare.Domain.Common;
using Healthcare.Domain.Entities;
using Healthcare.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<PatientProfile> PatientProfiles => Set<PatientProfile>();
    public DbSet<DoctorProfile> DoctorProfiles => Set<DoctorProfile>();
    public DbSet<OtpCode> OtpCodes => Set<OtpCode>();
    public DbSet<DoctorApprovalRequest> DoctorApprovalRequests => Set<DoctorApprovalRequest>();
    public DbSet<QrCode> QrCodes => Set<QrCode>();
    public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
    public DbSet<MedicalImage> MedicalImages => Set<MedicalImage>();
    public DbSet<HistoricalUpload> HistoricalUploads => Set<HistoricalUpload>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>(entity =>
        {
            entity.Property(x => x.FullName).HasMaxLength(200).IsRequired();
            entity.Property(x => x.NationalId).HasMaxLength(50).IsRequired();
            entity.Property(x => x.PinHash).HasMaxLength(500).IsRequired();
            entity.HasIndex(x => x.NationalId).IsUnique();
        });

        builder.Entity<PatientProfile>(entity =>
        {
            entity.HasOne(x => x.User).WithOne(x => x.PatientProfile).HasForeignKey<PatientProfile>(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(x => x.UserId).IsUnique();
        });

        builder.Entity<DoctorProfile>(entity =>
        {
            entity.Property(x => x.MedicalSyndicateNumber).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.MedicalSyndicateNumber).IsUnique();
            entity.HasOne(x => x.User).WithOne(x => x.DoctorProfile).HasForeignKey<DoctorProfile>(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<OtpCode>(entity =>
        {
            entity.Property(x => x.CodeHash).HasMaxLength(500).IsRequired();
            entity.Property(x => x.Purpose).HasConversion<string>().HasMaxLength(50);
            entity.HasOne(x => x.User).WithMany(x => x.OtpCodes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            entity.Ignore(x => x.IsConsumed);
        });

        builder.Entity<DoctorApprovalRequest>(entity =>
        {
            entity.Property(x => x.MedicalSyndicateCardPath).HasMaxLength(500).IsRequired();
            entity.Property(x => x.Status).HasConversion<string>().HasMaxLength(50).HasDefaultValue(DoctorApprovalStatus.Pending);
            entity.Property(x => x.RejectionReason).HasMaxLength(500);
            entity.HasOne(x => x.DoctorProfile).WithOne(x => x.ApprovalRequest).HasForeignKey<DoctorApprovalRequest>(x => x.DoctorProfileId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.ReviewedByAdmin).WithMany().HasForeignKey(x => x.ReviewedByAdminId).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<QrCode>(entity =>
        {
            entity.Property(x => x.Token).HasMaxLength(128).IsRequired();
            entity.Property(x => x.ImagePath).HasMaxLength(500).IsRequired();
            entity.HasIndex(x => x.Token).IsUnique();
            entity.HasOne(x => x.User).WithMany(x => x.QrCodes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<MedicalRecord>(entity =>
        {
            entity.Property(x => x.Diagnosis).HasMaxLength(4000).IsRequired();
            entity.Property(x => x.DoctorName).HasMaxLength(200).IsRequired();
            entity.Property(x => x.MedicalSyndicateNumber).HasMaxLength(100).IsRequired();
            entity.HasOne(x => x.PatientProfile).WithMany(x => x.MedicalRecords).HasForeignKey(x => x.PatientProfileId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.DoctorProfile).WithMany(x => x.MedicalRecords).HasForeignKey(x => x.DoctorProfileId).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<MedicalImage>(entity =>
        {
            entity.Property(x => x.FilePath).HasMaxLength(500).IsRequired();
            entity.Property(x => x.ContentType).HasMaxLength(100).IsRequired();
            entity.HasOne(x => x.MedicalRecord).WithMany(x => x.PrescriptionImages).HasForeignKey(x => x.MedicalRecordId).OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<HistoricalUpload>(entity =>
        {
            entity.Property(x => x.FilePath).HasMaxLength(500).IsRequired();
            entity.Property(x => x.ContentType).HasMaxLength(100).IsRequired();
            entity.HasOne(x => x.PatientProfile).WithMany(x => x.HistoricalUploads).HasForeignKey(x => x.PatientProfileId).OnDelete(DeleteBehavior.Cascade);
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Modified) entry.Entity.UpdatedAtUtc = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
