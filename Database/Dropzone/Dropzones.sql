CREATE TABLE [Dropzone].[Dropzones]
(
    [Id]            INT                 NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name]          NVARCHAR(256)       NOT NULL,
    [CountryCode]   NVARCHAR(2)         NOT NULL
)
