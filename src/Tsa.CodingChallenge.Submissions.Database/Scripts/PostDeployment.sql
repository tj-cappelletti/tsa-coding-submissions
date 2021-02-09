/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r ./myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/

--Sequence doesn't matter with these
:r ./SeedData/dbo.DataTypes.Data.sql
:r ./SeedData/dbo.ProgrammingLanguages.Data.sql

--Need Roles before Logins
:r ./SeedData/dbo.Roles.Data.sql
:r ./SeedData/dbo.Logins.data.sql

--Need Problems before Test Data Sets
:r ./SeedData/dbo.Problems.Data.sql
:r ./SeedData/dbo.TestDataSets.Data.sql