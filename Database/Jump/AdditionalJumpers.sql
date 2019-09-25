CREATE TABLE [Jump].[AdditionalJumpers]
(
    [JumpId]        INT NOT NULL,
    [PersonId]      INT NOT NULL,
    CONSTRAINT [PK_AdditionalJumper] PRIMARY KEY ([JumpId], [PersonId]),
    CONSTRAINT [FK_Jump.AdditionalJumpers.JumpId_Jump.Jumps.Id]         FOREIGN KEY ([JumpId])      REFERENCES [Jump].[Jumps]([Id]),
    CONSTRAINT [FK_Jump.AdditionalJumpers.PersonId_Person.Persons.Id]   FOREIGN KEY ([PersonId])    REFERENCES [Person].[Persons]([Id])
)
