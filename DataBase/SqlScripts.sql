IF (EXISTS (SELECT name 
FROM master.dbo.sysdatabases 
WHERE ('[' + name + ']' = 'MyMusic'
OR name = 'MyMusic')))
BEGIN
	DROP DATABASE MyMusic
END

GO
CREATE DATABASE MyMusic
GO

USE MyMusic
GO

CREATE TABLE Music(
Id INT IDENTITY,
Title VARCHAR(100),
Author VARCHAR(100),
DurationTicks BIGINT
)
