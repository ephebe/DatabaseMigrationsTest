CREATE TABLE [dbo].[Person]
(
	[PersonId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NCHAR(500) NOT NULL, 
    [LastName] NCHAR(255) NOT NULL, 
    [DateOfBirth] DATE NOT NULL
)
