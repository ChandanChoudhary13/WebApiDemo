IF OBJECT_ID('Contacts', 'U') IS NULL
BEGIN
	CREATE TABLE Contacts
	(
		ContactId			INT IDENTITY(1,1) PRIMARY KEY,
		FirstName			VARCHAR(20),
		LastName			VARCHAR(20),
		Email				VARCHAR(30),
		PhoneNumber			VARCHAR(10),
		Status				BIT,
		CreatedDate			DATETIME DEFAULT GETDATE(),
		UpdatedDate			DATETIME DEFAULT GETDATE()
	)
END
GO
