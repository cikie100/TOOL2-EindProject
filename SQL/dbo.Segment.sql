CREATE TABLE [dbo].[Segment]
(
	[SegmentId] INT NOT NULL IDENTITY, 
    [BeginKnoopId] INT NULL, 
    [EindKnoopId] INT NULL, 
    CONSTRAINT [PK_Segment] PRIMARY KEY ([SegmentId]), 
)
