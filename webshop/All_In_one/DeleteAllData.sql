EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL"
GO

-- DELETE
EXEC sp_MSForEachTable "DELETE FROM ?"
GO

EXEC sp_MSforeachtable "ALTER TABLE ? WITH NOCHECK CHECK CONSTRAINT ALL"
GO

EXEC sp_MSforeachtable "DBCC CHECKIDENT('?', RESEED, 0)"
GO

-- TRUNCATE all table
EXEC sp_MSForEachTable "TRUNCATE TABLE ?"
GO

-- get table seed
SELECT IDENT_CURRENT('TableName') AS SeedValue;
EXEC sp_MSforEachtable "IDENT_CURRENT(?) AS SeedValue"