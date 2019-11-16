CREATE TABLE [Gear].[CanopyModels]
(
    [Id]                INT             NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name]              NVARCHAR(256)   NOT NULL,
    [Cells]             INT             NOT NULL,
    [Elliptical]        BIT             NOT NULL,
    [ManufacturerId]    INT             NOT NULL, 
    [CanopyLevel]       INT             NOT NULL, 
    [CanopyType]        INT             NOT NULL

    CONSTRAINT [FK_CanopyModels_Gear.Manufacturers] FOREIGN KEY ([ManufacturerId])  REFERENCES [Gear].[Manufacturers]([Id]),
    CONSTRAINT [FK_GearModels_Gear.CanopyLevel]     FOREIGN KEY ([CanopyLevel])     REFERENCES [Gear].[CanopyLevels]([EnumKey]),
    CONSTRAINT [FK_GearModels_Gear.CanopyType]      FOREIGN KEY ([CanopyType])      REFERENCES [Gear].[CanopyTypes]([EnumKey])
)