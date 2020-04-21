CREATE TABLE [dbo].[Knoop_Segment]
(
	[knoopId] INT NOT NULL , 
    [SegmentId] INT NOT NULL,
	 PRIMARY KEY CLUSTERED ([knoopId] ASC, [SegmentId] ASC), 
    CONSTRAINT [FK_Knoop_Segment_ToSegment] FOREIGN KEY ([SegmentId]) REFERENCES [dbo].[Segment]([SegmentId]), 
    CONSTRAINT [FK_Knoop_Segment_ToKnoop] FOREIGN KEY ([knoopId]) REFERENCES [dbo].[Knoop]([knoopId]),


)
