CREATE TABLE [Gear].[ContainerModels]
(
    [Id]                INT             NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name]              NVARCHAR(256)   NOT NULL,
    [ManufacturerId]    INT             NOT NULL, 
    CONSTRAINT [FK_ContainerModels_Gear.Manufacturers] FOREIGN KEY ([ManufacturerId]) REFERENCES [Gear].[Manufacturers]([Id])
)
