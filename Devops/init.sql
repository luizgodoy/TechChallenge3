IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'TechChallenge2')
BEGIN
    CREATE DATABASE TechChallenge2;
END
GO

USE TechChallenge2;
GO

IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'tech_challenge')
BEGIN
    CREATE LOGIN tech_challenge WITH PASSWORD = 'tech@2024';
END
GO

IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'tech_challenge')
BEGIN
    CREATE USER tech_challenge FOR LOGIN tech_challenge;
END
GO

IF NOT EXISTS (SELECT dp.name 
               FROM sys.database_principals dp
               JOIN sys.database_role_members drm ON dp.principal_id = drm.member_principal_id
               JOIN sys.database_principals rp ON rp.principal_id = drm.role_principal_id
               WHERE dp.name = 'tech_challenge' AND rp.name = 'db_owner')
BEGIN
    ALTER ROLE db_owner ADD MEMBER tech_challenge;
END
GO
