CREATE TABLE [dbo].[Provincie] (
    [provincieID]  INT        IDENTITY (1, 1) NOT NULL,
    [provincienaam] NCHAR (35) NULL,
    [taalcode]     NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([provincieID] ASC)
);

