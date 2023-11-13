
BEGIN TRY
	BEGIN TRANSACTION;
		IF OBJECT_ID (N'test.dbo.TypeFile', N'U') IS NULL 
		begin
			CREATE TABLE test.dbo.TypeFile
			(
				IdTypeFile int identity(1,1) not null primary key,
				Descripcion nvarchar(50) not null,
				Estatus bit not null default 1,
				Created smalldatetime default getdate()
			)
		end

		IF OBJECT_ID (N'test.dbo.UploadFile', N'U') IS NULL 
		begin
			CREATE TABLE test.dbo.UploadFile
			(
				IdFile int identity(1,1) not null primary key,
				Nombre nvarchar(50) not null,
				InternalName bit not null default 1,
				URL text not null,
				Estras text,
				IdTypeFile int not null,
				Created smalldatetime default getdate()
				foreign key (IdTypeFile) References test.dbo.TypeFile (IdTypeFile)
			)
		end
	COMMIT TRANSACTION;
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER() AS ErrNum, ERROR_MESSAGE() AS ErrMsg;
	IF (XACT_STATE()) <> 0
    	BEGIN
        ROLLBACK TRANSACTION;
    	END;
END CATCH;
GO
