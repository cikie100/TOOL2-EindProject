CREATE TABLE [dbo].[Gemeente] (
    [gemeenteId]   INT        IDENTITY (1, 1) NOT NULL,
    [gemeenteNaam] NCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([gemeenteId] ASC)
);

