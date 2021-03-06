﻿CREATE TABLE [dbo].[Provincie_Gemeente] (
    [provincieID] INT NOT NULL,
    [gemeenteId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([provincieID] ASC, [gemeenteId] ASC),
    CONSTRAINT [FK_Gemeente_Provincie_Provincie] FOREIGN KEY ([provincieID]) REFERENCES [dbo].[Provincie] ([provincieID]),
    CONSTRAINT [FK_Gemeente_Provincie_Gemeente] FOREIGN KEY ([gemeenteId]) REFERENCES [dbo].[Gemeente] ([gemeenteId])
);

