CREATE TABLE [dbo].[Straat] (
    [straatId]   INT         NOT NULL IDENTITY,
    [straatNaam] NCHAR (100) NULL,
    [lengte]     INT         NULL,
    [graafID]    INT         NULL,
    PRIMARY KEY CLUSTERED ([straatId] ASC),
    CONSTRAINT [FK_Straat_Graaf] FOREIGN KEY ([graafID]) REFERENCES [dbo].[graaf] ([GraafId])
);

