CREATE TABLE [dbo].[BusinessUser]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [BusinessName] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(100) NOT NULL, 
    [Info] NVARCHAR(500) NOT NULL
)
