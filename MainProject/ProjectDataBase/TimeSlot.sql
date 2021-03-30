CREATE TABLE [dbo].[TimeSlot]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [BusinessId] INT NOT NULL, 
    [DayOTWeek] NVARCHAR(50) NOT NULL, 
    [StartTime] DATETIME NOT NULL, 
    [EndTime] DATETIME NOT NULL, 
    [NumberOfSpots] INT NOT NULL
)
