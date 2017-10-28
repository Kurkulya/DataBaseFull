CREATE TABLE [dbo].[phones]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Phone] VARCHAR(50) NULL, 
    [Person_Id] INT NOT NULL
)
