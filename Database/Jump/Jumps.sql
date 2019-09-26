CREATE TABLE [Jump].[Jumps]
(
    [Id]            INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PersonId]      INT NOT NULL,
    [CanopyId]      INT NOT NULL,
    [ContainerId]   INT NOT NULL,
    [Number]        INT NOT NULL,
    [Altitude]      INT NOT NULL,    
    [DropzoneId]    INT NOT NULL,
    [SignedById]    INT NULL
    CONSTRAINT [FK_Jump.JumpsPersonId_Person.Persons.Id]    FOREIGN KEY ([PersonId])    REFERENCES [Person].[Persons]([Id]),
    CONSTRAINT [FK_Jump.CanopyId_Gear.Canopies.Id]          FOREIGN KEY ([CanopyId])    REFERENCES [Gear].[Canopies]([Id]),
    CONSTRAINT [FK_Jump.ContainerId_Gear.Containers.Id]     FOREIGN KEY ([ContainerId]) REFERENCES [Gear].[Containers]([Id]),
    CONSTRAINT [FK_Jump.DropzoneId_Dropzone.Dropzones.Id]   FOREIGN KEY ([DropzoneId])  REFERENCES [Dropzone].[Dropzones]([Id]),
    CONSTRAINT [FK_Jump.JumpsSignedById_Person.Persons.Id]  FOREIGN KEY ([SignedById])  REFERENCES [Person].[Persons]([Id])
)
