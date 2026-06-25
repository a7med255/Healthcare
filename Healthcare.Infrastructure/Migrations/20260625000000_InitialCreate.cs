using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healthcare.Infrastructure.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
CREATE TABLE [AspNetRoles] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
CREATE TABLE [AspNetUsers] (
    [Id] uniqueidentifier NOT NULL,
    [FullName] nvarchar(200) NOT NULL,
    [NationalId] nvarchar(50) NOT NULL,
    [PinHash] nvarchar(500) NOT NULL,
    [IsIdentityVerified] bit NOT NULL,
    [CreatedAtUtc] datetime2 NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [AspNetUserRoles] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [AspNetUserTokens] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [PatientProfiles] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [CreatedAtUtc] datetime2 NOT NULL,
    [UpdatedAtUtc] datetime2 NULL,
    CONSTRAINT [PK_PatientProfiles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PatientProfiles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);
CREATE TABLE [DoctorProfiles] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [MedicalSyndicateNumber] nvarchar(100) NOT NULL,
    [IsApproved] bit NOT NULL,
    [CreatedAtUtc] datetime2 NOT NULL,
    [UpdatedAtUtc] datetime2 NULL,
    CONSTRAINT [PK_DoctorProfiles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DoctorProfiles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);
CREATE TABLE [OtpCodes] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [CodeHash] nvarchar(500) NOT NULL,
    [Purpose] nvarchar(50) NOT NULL,
    [ExpiresAtUtc] datetime2 NOT NULL,
    [ConsumedAtUtc] datetime2 NULL,
    [CreatedAtUtc] datetime2 NOT NULL,
    [UpdatedAtUtc] datetime2 NULL,
    CONSTRAINT [PK_OtpCodes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OtpCodes_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [QrCodes] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [Token] nvarchar(128) NOT NULL,
    [ImagePath] nvarchar(500) NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedAtUtc] datetime2 NOT NULL,
    [UpdatedAtUtc] datetime2 NULL,
    CONSTRAINT [PK_QrCodes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_QrCodes_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [DoctorApprovalRequests] (
    [Id] uniqueidentifier NOT NULL,
    [DoctorProfileId] uniqueidentifier NOT NULL,
    [MedicalSyndicateCardPath] nvarchar(500) NOT NULL,
    [Status] nvarchar(50) NOT NULL DEFAULT N'Pending',
    [ReviewedByAdminId] uniqueidentifier NULL,
    [ReviewedAtUtc] datetime2 NULL,
    [RejectionReason] nvarchar(500) NULL,
    [CreatedAtUtc] datetime2 NOT NULL,
    [UpdatedAtUtc] datetime2 NULL,
    CONSTRAINT [PK_DoctorApprovalRequests] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DoctorApprovalRequests_AspNetUsers_ReviewedByAdminId] FOREIGN KEY ([ReviewedByAdminId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DoctorApprovalRequests_DoctorProfiles_DoctorProfileId] FOREIGN KEY ([DoctorProfileId]) REFERENCES [DoctorProfiles] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [MedicalRecords] (
    [Id] uniqueidentifier NOT NULL,
    [PatientProfileId] uniqueidentifier NOT NULL,
    [DoctorProfileId] uniqueidentifier NOT NULL,
    [Diagnosis] nvarchar(4000) NOT NULL,
    [DoctorName] nvarchar(200) NOT NULL,
    [VisitDateUtc] datetime2 NOT NULL,
    [MedicalSyndicateNumber] nvarchar(100) NOT NULL,
    [CreatedAtUtc] datetime2 NOT NULL,
    [UpdatedAtUtc] datetime2 NULL,
    CONSTRAINT [PK_MedicalRecords] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MedicalRecords_DoctorProfiles_DoctorProfileId] FOREIGN KEY ([DoctorProfileId]) REFERENCES [DoctorProfiles] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MedicalRecords_PatientProfiles_PatientProfileId] FOREIGN KEY ([PatientProfileId]) REFERENCES [PatientProfiles] ([Id]) ON DELETE NO ACTION
);
CREATE TABLE [HistoricalUploads] (
    [Id] uniqueidentifier NOT NULL,
    [PatientProfileId] uniqueidentifier NOT NULL,
    [FilePath] nvarchar(500) NOT NULL,
    [ContentType] nvarchar(100) NOT NULL,
    [FileSizeBytes] bigint NOT NULL,
    [CreatedAtUtc] datetime2 NOT NULL,
    [UpdatedAtUtc] datetime2 NULL,
    CONSTRAINT [PK_HistoricalUploads] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HistoricalUploads_PatientProfiles_PatientProfileId] FOREIGN KEY ([PatientProfileId]) REFERENCES [PatientProfiles] ([Id]) ON DELETE CASCADE
);
CREATE TABLE [MedicalImages] (
    [Id] uniqueidentifier NOT NULL,
    [MedicalRecordId] uniqueidentifier NOT NULL,
    [FilePath] nvarchar(500) NOT NULL,
    [ContentType] nvarchar(100) NOT NULL,
    [FileSizeBytes] bigint NOT NULL,
    [CreatedAtUtc] datetime2 NOT NULL,
    [UpdatedAtUtc] datetime2 NULL,
    CONSTRAINT [PK_MedicalImages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MedicalImages_MedicalRecords_MedicalRecordId] FOREIGN KEY ([MedicalRecordId]) REFERENCES [MedicalRecords] ([Id]) ON DELETE CASCADE
);
CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
CREATE UNIQUE INDEX [IX_AspNetUsers_NationalId] ON [AspNetUsers] ([NationalId]);
CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
CREATE UNIQUE INDEX [IX_DoctorApprovalRequests_DoctorProfileId] ON [DoctorApprovalRequests] ([DoctorProfileId]);
CREATE INDEX [IX_DoctorApprovalRequests_ReviewedByAdminId] ON [DoctorApprovalRequests] ([ReviewedByAdminId]);
CREATE UNIQUE INDEX [IX_DoctorProfiles_MedicalSyndicateNumber] ON [DoctorProfiles] ([MedicalSyndicateNumber]);
CREATE UNIQUE INDEX [IX_DoctorProfiles_UserId] ON [DoctorProfiles] ([UserId]);
CREATE INDEX [IX_HistoricalUploads_PatientProfileId] ON [HistoricalUploads] ([PatientProfileId]);
CREATE INDEX [IX_MedicalImages_MedicalRecordId] ON [MedicalImages] ([MedicalRecordId]);
CREATE INDEX [IX_MedicalRecords_DoctorProfileId] ON [MedicalRecords] ([DoctorProfileId]);
CREATE INDEX [IX_MedicalRecords_PatientProfileId] ON [MedicalRecords] ([PatientProfileId]);
CREATE INDEX [IX_OtpCodes_UserId] ON [OtpCodes] ([UserId]);
CREATE UNIQUE INDEX [IX_PatientProfiles_UserId] ON [PatientProfiles] ([UserId]);
CREATE UNIQUE INDEX [IX_QrCodes_Token] ON [QrCodes] ([Token]);
CREATE INDEX [IX_QrCodes_UserId] ON [QrCodes] ([UserId]);
""");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
DROP TABLE [MedicalImages];
DROP TABLE [HistoricalUploads];
DROP TABLE [DoctorApprovalRequests];
DROP TABLE [OtpCodes];
DROP TABLE [QrCodes];
DROP TABLE [AspNetRoleClaims];
DROP TABLE [AspNetUserClaims];
DROP TABLE [AspNetUserLogins];
DROP TABLE [AspNetUserRoles];
DROP TABLE [AspNetUserTokens];
DROP TABLE [MedicalRecords];
DROP TABLE [AspNetRoles];
DROP TABLE [DoctorProfiles];
DROP TABLE [PatientProfiles];
DROP TABLE [AspNetUsers];
""");
    }
}
