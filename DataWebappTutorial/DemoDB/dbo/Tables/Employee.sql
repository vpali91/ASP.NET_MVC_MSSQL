CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EmployeeID] INT NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [EmailAddress] VARCHAR(50) NOT NULL
)
