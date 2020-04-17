CREATE TABLE [dbo].[provincie_gemeente]
(
	[gemeenteId] INT NOT NULL , 
    [provincieId] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([provincieId] ASC,[gemeenteId]ASC), 
    CONSTRAINT [FK_provincie_gemeente_Provincie] FOREIGN KEY ([gemeenteId]) REFERENCES [dbo].[Provincie], 
    CONSTRAINT [FK_provincie_gemeente_Gemeente] FOREIGN KEY ([gemeenteId]) REFERENCES [dbo].[Gemeente],

)
