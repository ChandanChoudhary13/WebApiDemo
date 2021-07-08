SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Chandan Choudhary
-- Create date: 07-08-2021
-- Description: To Delete Contacts

-- Changes History :

-- Test Cases :
--EXEC DeleteContact @ContactId=1
-- ============================================= 
CREATE OR ALTER PROC [dbo].[DeleteContact]  
 @ContactId INT  
AS  
BEGIN  
 DELETE FROM dbo.Contacts WHERE ContactId = @ContactId  
 RETURN @ContactId
END
