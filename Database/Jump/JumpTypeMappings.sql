CREATE TABLE [Jump].[JumpTypeMappings]
(
    [JumpId]            INT NOT NULL,
    [JumpTypeId]        INT NOT NULL,
    CONSTRAINT [PK_JumpTypeMapping] PRIMARY KEY ([JumpId], [JumpTypeId]),
    CONSTRAINT [FK_Jump.JumpTypeMappings.JumpId_Jump.Jumps.Id]          FOREIGN KEY ([JumpId])      REFERENCES [Jump].[Jumps]([Id]),
    CONSTRAINT [FK_Jump.JumpTypeMappings.JumpTypId_Jump.JumpTypes.Id]   FOREIGN KEY ([JumpTypeId])  REFERENCES [Jump].[JumpTypes]([Id])
)