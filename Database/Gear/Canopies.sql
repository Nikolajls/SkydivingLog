CREATE TABLE [Gear].[Canopies]
(
    [Id]                INT             NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [SquareFoot]        INT             NOT NULL,
    [SerialNumber]      NVARCHAR(256)   NOT NULL,
    [ManufacturedDate]  DATETIME        NOT NULL,
    [CanopyModelId]     INT             NOT NULL,
    CONSTRAINT [FK_Canopies_Gear.CanopyModels] FOREIGN KEY ([CanopyModelId]) REFERENCES [Gear].[CanopyModels](Id)
)
