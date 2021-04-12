CREATE TABLE [dbo].[BusinessUser]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [BusinessName] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(150) NOT NULL, 
    [Email] NVARCHAR(150) NOT NULL, 
    [Info] NVARCHAR(MAX) NULL, 
    [Sector] NVARCHAR(50) NULL
)
