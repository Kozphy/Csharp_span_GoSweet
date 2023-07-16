EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL"
GO

EXEC sp_MSForEachTable "DELETE FROM ?"
GO

EXEC sp_MSforeachtable "DBCC CHECKIDENT('?', RESEED, 0)"
GO

EXEC sp_MSforeachtable "ALTER TABLE ? WITH NOCHECK CHECK CONSTRAINT ALL"
GO