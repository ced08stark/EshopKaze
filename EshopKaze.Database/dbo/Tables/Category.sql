CREATE TABLE [dbo].[Category] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (50) NULL,
    [UserId] INT           NULL,
    CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Categorie_Categorie] FOREIGN KEY ([Name]) REFERENCES [dbo].[Category] ([Name]),
    CONSTRAINT [IX_Categorie] UNIQUE NONCLUSTERED ([Name] ASC)
);

