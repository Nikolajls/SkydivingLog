CREATE TABLE [Gear].[Containers]
(
    [Id]                INT             NOT NULL PRIMARY KEY IDENTITY(1,1),
    [SerialNumber]      NVARCHAR(256)   NOT NULL,
    [ManufacturedDate]  DATETIME        NOT NULL,
    [ContainerModelId]  INT             NOT NULL,
    CONSTRAINT [FK_Containers.ContainerModelId_Gear.ContainerModels.Id] FOREIGN KEY ([ContainerModelId]) REFERENCES  [Gear].[ContainerModels]([Id])
)
