CREATE TABLE [dbo].[Graaf_Knoop]
(
	[GraafId] INT NOT NULL, 
    [knoopId] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([GraafId] ASC, [knoopId] ASC),

    CONSTRAINT [FK_GraafId_Graaf] FOREIGN KEY ([GraafId]) REFERENCES [dbo].[graaf] ([GraafId]),
    CONSTRAINT [FK_knoopId_Knoop] FOREIGN KEY ([knoopId]) REFERENCES  [dbo].[Knoop] ([knoopId])


)	
