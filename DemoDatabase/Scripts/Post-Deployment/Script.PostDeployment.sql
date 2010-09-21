/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[aspnet_Applications] ([ApplicationName], [LoweredApplicationName], [ApplicationId], [Description]) VALUES (N'/', N'/', N'c16ce227-83cf-4b48-ba12-4dfd2c009947', NULL);

INSERT INTO [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES (N'c16ce227-83cf-4b48-ba12-4dfd2c009947', N'086949c2-9716-4d58-9149-4ef44cf4f7de', N'asmunde', N'asmunde', NULL, 0, CAST(0x00009DF600E6F5C3 AS DateTime));
INSERT INTO [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES (N'c16ce227-83cf-4b48-ba12-4dfd2c009947', N'72bad2c8-d3b7-4aa7-8835-71c9eb573bd0', N'hansolno', N'hansolno', NULL, 0, CAST(0x00009DF600E6F5C3 AS DateTime));

INSERT INTO [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) VALUES (N'c16ce227-83cf-4b48-ba12-4dfd2c009947', N'04305fd3-e3ac-44c0-9686-725c40338858', N'Administrator', N'administrator', NULL);
INSERT INTO [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) VALUES (N'c16ce227-83cf-4b48-ba12-4dfd2c009947', N'1f0ef013-1ac5-42f6-b5de-8848ced365e9', N'User', N'user', NULL);

INSERT INTO [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES (N'086949c2-9716-4d58-9149-4ef44cf4f7de', N'04305fd3-e3ac-44c0-9686-725c40338858');
INSERT INTO [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES (N'086949c2-9716-4d58-9149-4ef44cf4f7de', N'1f0ef013-1ac5-42f6-b5de-8848ced365e9');
INSERT INTO [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES (N'72bad2c8-d3b7-4aa7-8835-71c9eb573bd0', N'1f0ef013-1ac5-42f6-b5de-8848ced365e9');

INSERT INTO [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (N'c16ce227-83cf-4b48-ba12-4dfd2c009947', N'086949c2-9716-4d58-9149-4ef44cf4f7de', N'kHBg++yQv91L+muF0TXpCFODcjc=', 1, N'uXzwtROLct8ySp44S6GcaA==', NULL, N'aasmund.eldhuset@bekk.no', N'aasmund.eldhuset@bekk.no', NULL, NULL, 1, 0, CAST(0x00009DF600E6F49C AS DateTime), CAST(0x00009DF600E6F5C3 AS DateTime), CAST(0x00009DF600E6F49C AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL);
INSERT INTO [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (N'c16ce227-83cf-4b48-ba12-4dfd2c009947', N'72bad2c8-d3b7-4aa7-8835-71c9eb573bd0', N'kHBg++yQv91L+muF0TXpCFODcjc=', 1, N'uXzwtROLct8ySp44S6GcaA==', NULL, N'hans.olav.norheim@microsoft.com', N'hans.olav.norheim@microsoft.com', NULL, NULL, 1, 0, CAST(0x00009DF600E6F49C AS DateTime), CAST(0x00009DF600E6F5C3 AS DateTime), CAST(0x00009DF600E6F49C AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL);

INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'common', N'1', 1);
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'health monitoring', N'1', 1);
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'membership', N'1', 1);
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'personalization', N'1', 1);
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'profile', N'1', 1);
INSERT INTO [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'role manager', N'1', 1);
