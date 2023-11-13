
USE test
GO

CREATE PROCEDURE CreateTypeFile 
	@descripcion nvarchar(50) null
AS
	INSERT INTO test.dbo.TypeFile (Descripcion) 
	values (@descripcion);
	SELECT @@IDENTITY AS [Last-Inserted Identity Value];
GO

