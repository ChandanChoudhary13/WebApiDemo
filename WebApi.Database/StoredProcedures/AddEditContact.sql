SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Chandan Choudhary
-- Create date: 07-08-2021
-- Description: To Inser and Update Contacts

-- Changes History :

-- Test Cases :
--EXEC AddEditContact @ContactId = 0, @FirstName = 'chadnan77', @LastName = 'Choudhary', @Email= 'ramesh@ramlal.com', @PhoneNumber = '74747474747', @Status = 1  
--EXEC AddEditContact @ContactId = 1004, @FirstName = 'Ramesh1', @LastName = 'Choudhary', @Email= 'ramesh@rameshjaipur.com', @PhoneNumber = '98989898', @Status = 0
-- =============================================  
CREATE OR ALTER PROC [dbo].[AddEditContact]  
 @ContactId INT = NULL,  
 @FirstName varchar(20),  
 @LastName varchar(20),  
 @Email varchar(30),  
 @PhoneNumber varchar(10),  
 @Status BIT  
AS  
BEGIN  
 IF NOT EXISTS(SELECT 1 from Contacts where ContactId=@ContactId)
	 BEGIN  
		  INSERT INTO dbo.Contacts(FirstName,LastName,Email,PhoneNumber,Status,CreatedDate) 
		  VALUES (@FirstName,@LastName,@Email,@PhoneNumber,@Status,GETDATE())  
		  Select @@IDENTITY As Id
	 END  
 ELSE  
	 BEGIN  
		  UPDATE dbo.Contacts  
		  SET FirstName = @FirstName  
		  ,LastName = @LastName  
		  ,Email = @Email  
		  ,PhoneNumber = @PhoneNumber  
		  ,Status = @Status  
		  ,UpdatedDate = GETDATE()   
		  WHERE ContactId = @ContactId
		  Select @ContactId As Id
	 END  
END  
GO