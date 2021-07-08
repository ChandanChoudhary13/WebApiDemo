SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      Chandan Choudhary
-- Create date: 07-08-2021
-- Description: To get Contacts All or By Id

-- Changes History :

-- Test Cases :
--EXEC GetContacts
--EXEC GetContacts @ContactId = 0
--EXEC GetContacts @ContactId = 2
-- ============================================= 
CREATE OR ALTER PROC [dbo].[GetContacts]
	@ContactId INT = NULL
AS
BEGIN
		Select ContactId
		,FirstName
		,LastName
		,Email
		,PhoneNumber
		,Status
		,CreatedDate
		,UpdatedDate from dbo.Contacts WHERE @ContactId IS NULL OR ContactId = @ContactId
END
GO