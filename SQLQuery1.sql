DROP TABLE IF EXISTS dbo.Patients;
DROP TABLE IF EXISTS dbo.Doctors;
DROP TABLE IF EXISTS dbo.__MigrationHistory;

CREATE TABLE [dbo].[Patients] (
    [Id]                              INT IDENTITY (1, 1) NOT NULL,
    [Name]                            NVARCHAR (100) NOT NULL,
    [Complaints]                      NVARCHAR (100) NOT NULL,
    [Health]                          INT NOT NULL DEFAULT 15,
    [DoctorId]                        INT NULL,
    [DiagnosisName]                   NVARCHAR (100) NULL,
    [DiagnosisCathegory]              NVARCHAR (100) NULL,
    [DiagnosisRequiredExperience]     INT NULL,
    [RealDiagnosisName]               NVARCHAR (100) NULL,
    [RealDiagnosisCathegory]          NVARCHAR (100) NULL,
    [RealDiagnosisRequiredExperience] INT NULL,
    [RealDiagnosisDestructivity]      INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Doctors] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [Specialization]  NVARCHAR (100) NOT NULL,
    [Name]            NVARCHAR (100) NOT NULL,
    [ExperienceYears] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);