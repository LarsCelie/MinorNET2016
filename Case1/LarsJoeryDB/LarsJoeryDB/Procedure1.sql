CREATE PROCEDURE [dbo].[csp_newClient_i]
	@name varchar(100),
	@email varchar(30),
	@address int = null
AS
	SELECT @name, @email
RETURN 0
