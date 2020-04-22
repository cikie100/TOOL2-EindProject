CREATE TABLE [dbo].[Punt] (
    [SegmId] INT        NOT NULL,
    [puntX]  FLOAT (53) NOT NULL,
    [puntY]  FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([SegmId] ASC, [puntX] ASC, [puntY] ASC), 
    CONSTRAINT [FK_Punt_ToSegment] FOREIGN KEY ([SegmId]) REFERENCES [dbo].[Segment]([SegmentId])
);

