INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'195f7116-dd57-4bd5-b123-7193f49a6357', N'admin@timesheet.com', N'ADMIN@TIMESHEET.COM', N'admin@timesheet.com', N'ADMIN@TIMESHEET.COM', 1, N'AQAAAAEAACcQAAAAEOTVMDLfzwp9V9bj0howMaTnBDR7sYRUkU47C5/tvLJMiqWC+PwbH8k7ZungXpYtMg==', N'5DWOERAKONCPSXNAXGBDRK47B2CDCDXW', N'6c4d0d0c-f193-4da2-8138-d4e85fa9ce63', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Department] ON
INSERT INTO [dbo].[Department] ([Id], [Name], [ContactPhoneNumber]) VALUES (1, N'Human Resources', N'02134561123')
INSERT INTO [dbo].[Department] ([Id], [Name], [ContactPhoneNumber]) VALUES (2, N'Information Technology Support', N'02134561112')
INSERT INTO [dbo].[Department] ([Id], [Name], [ContactPhoneNumber]) VALUES (3, N'Finance', N'021345671123')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON
INSERT INTO [dbo].[Employee] ([Id], [Name], [ContactPhoneNumber]) VALUES (1, N'Ken Smith', N'021877654321')
INSERT INTO [dbo].[Employee] ([Id], [Name], [ContactPhoneNumber]) VALUES (2, N'Garry Simon', N'02166690123')
INSERT INTO [dbo].[Employee] ([Id], [Name], [ContactPhoneNumber]) VALUES (3, N'Ted Wilkinson', N'02199934567')
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[TimeRecord] ON
INSERT INTO [dbo].[TimeRecord] ([Id], [EmployeeId], [DepartmentId], [StartTime], [EndTime], [Date]) VALUES (1, 1, 1, N'2021-02-03 08:59:00', N'2021-02-03 15:59:00', N'2021-02-06 00:00:00')
INSERT INTO [dbo].[TimeRecord] ([Id], [EmployeeId], [DepartmentId], [StartTime], [EndTime], [Date]) VALUES (2, 2, 2, N'2021-02-03 08:00:00', N'2021-02-03 16:00:00', N'2021-02-12 00:00:00')
SET IDENTITY_INSERT [dbo].[TimeRecord] OFF