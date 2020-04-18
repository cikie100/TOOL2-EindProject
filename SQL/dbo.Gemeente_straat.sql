CREATE TABLE [dbo].[Gemeente_straat]
(
	[gemeenteId] INT NOT NULL, 
    [straatId] INT NOT NULL,
	PRIMARY KEY ([gemeenteId], [straatId]), 

	CONSTRAINT [FK_Gemeente_straat_straat] FOREIGN KEY ([straatId]) REFERENCES [dbo].[Straat]([straatId]), 
    CONSTRAINT [FK_Gemeente_straat_Gemeente] FOREIGN KEY ([gemeenteId]) REFERENCES [dbo].[Gemeente]([gemeenteId])

)
