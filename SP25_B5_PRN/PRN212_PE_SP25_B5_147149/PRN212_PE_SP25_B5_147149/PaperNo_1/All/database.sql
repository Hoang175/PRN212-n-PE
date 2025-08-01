USE [master]
GO
CREATE DATABASE [PE_PRN212_25SprB5]
GO
USE [PE_PRN212_25SprB5]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 15/12/2021 12:02:47 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Dob] [date] NOT NULL,
	[Sex] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[Department] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 15/12/2021 12:02:47 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [ntext] NULL,
	[StartDate] [date] NULL,
	[Type] [nvarchar](50) NULL,
	[Department] [int] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Department] ON 

GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (1, N'Integrated System')
GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (2, N'Software')
GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (3, N'Information Assurance')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

GO
INSERT [dbo].[Employee] ([Id], [Name], [Dob], [Sex], [Position], [Department]) VALUES (1, N'Tran Bao Han', CAST(N'1980-09-12' AS Date), N'Female', N'Developer', 1)
GO
INSERT [dbo].[Employee] ([Id], [Name], [Dob], [Sex], [Position], [Department]) VALUES (2, N'Quach Phu Thanh', CAST(N'1987-01-19' AS Date), N'Male', N'Developer', 2)
GO
INSERT [dbo].[Employee] ([Id], [Name], [Dob], [Sex], [Position], [Department]) VALUES (3, N'Chu Thanh Quang', CAST(N'1984-05-23' AS Date), N'Male', N'Leader', 1)
GO
INSERT [dbo].[Employee] ([Id], [Name], [Dob], [Sex], [Position], [Department]) VALUES (4, N'Trinh Tien Dung', CAST(N'1990-06-14' AS Date), N'Male', N'Developer', 2)
GO
INSERT [dbo].[Employee] ([Id], [Name], [Dob], [Sex], [Position], [Department]) VALUES (5, N'Phan Thu Thao', CAST(N'1990-03-12' AS Date), N'Female', N'Tester', 1)
GO
INSERT [dbo].[Employee] ([Id], [Name], [Dob], [Sex], [Position], [Department]) VALUES (6, N'Nguyen Xuan Quang', CAST(N'1987-01-19' AS Date), N'Male', N'Leader', 2)
GO
INSERT [dbo].[Employee] ([Id], [Name], [Dob], [Sex], [Position], [Department]) VALUES (7, N'Trinh Thu Hang', CAST(N'2000-05-12' AS Date), N'Female', N'Developer', 3)
GO
INSERT [dbo].[Employee] ([Id], [Name], [Dob], [Sex], [Position], [Department]) VALUES (8, N'Tran Hong Quan', CAST(N'1998-04-16' AS Date), N'Male', N'Leader', 3)
GO
INSERT [dbo].[Employee] ([Id], [Name], [Dob], [Sex], [Position], [Department]) VALUES (9, N'Pham The Tung', CAST(N'1984-09-12' AS Date), N'Male', N'Manager', 1)
GO
INSERT [dbo].[Employee] ([Id], [Name], [Dob], [Sex], [Position], [Department]) VALUES (10, N'Tran Manh Chien', CAST(N'1983-10-21' AS Date), N'Male', N'Manager', 2)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

GO
INSERT [dbo].[Project] ([Id], [Name], [Description], [StartDate], [Type], [Department]) VALUES (1, N'Contact Database for Estates Help Desk', N'The Helpdesk team currently have a Microsoft Access database which has been organically developed from scratch, by a former employee.  The Key Contacts Database has grown to become a critical operational asset, which is now shared with our key front line service provider, Estates Security. 

The Microsoft Access database technology is not supported by ISG. This project is to develop and alternative in a supported technology which will provide increased service resilience.', CAST(N'2020-10-12' AS Date), N'Software Product', 2)
GO
INSERT [dbo].[Project] ([Id], [Name], [Description], [StartDate], [Type], [Department]) VALUES (2, N'Annual Maria DB Upgrade', N'We require our MariaDB infrastructure to remain current and supportable, We will look to upgrade to latest stable and supported versions of Mariadb. 

Our last project to migrate to Mariadb added automation to the build and deployment of databases, we will build on the back of this to patch in an efficient automated manner. ', CAST(N'2019-12-12' AS Date), N'Consulting Project', 1)
GO
INSERT [dbo].[Project] ([Id], [Name], [Description], [StartDate], [Type], [Department]) VALUES (3, N'Digital Strategy Implementation', NULL, CAST(N'2020-09-03' AS Date), N'Consulting Project', 1)
GO
INSERT [dbo].[Project] ([Id], [Name], [Description], [StartDate], [Type], [Department]) VALUES (4, N'Enterprise Infrastructure Migrations', N'Migrate onto new i/f', CAST(N'2020-06-15' AS Date), N'IS Project', 1)
GO
INSERT [dbo].[Project] ([Id], [Name], [Description], [StartDate], [Type], [Department]) VALUES (5, N'Moodle Annual Upgrade', N'Planned annual upgrade of Moodle VLE platform.  

 We should be upgrading yearly, but jumping 2 versions at a time (upgrading in June/July each year).  The exact version each year will be dependent on our plugins and how quickly they can be tested/redeveloped by non-Moodle HQ developers. At present we expect to deploy in July the version that comes out in the December previous.  

Annual upgrade of Moodle platform to stay on supported version. Takes place in Semester 2 for delivery into production in July to fit with teaching pattern. ', CAST(N'2021-08-09' AS Date), N'Software Product', 2)
GO
INSERT [dbo].[Project] ([Id], [Name], [Description], [StartDate], [Type], [Department]) VALUES (6, N'Speaking Out', N'Catalogue (and promotion of) Lothian Gay and Lesbian Switchboard archives held by Lothian Health Services Archive within the Centre for Research Collections. Also includes selected digitisation and a public engagement/research enrichment component as a separate but related project (LUC036).

This project is funded by the Wellcome Trust Research Resources, with an award of £54,548.

The project was originally planned to run from May 2020 - April 2021 but has been temporarily postponed due to Covid. It is now likely to run from November 2021 to October 2022 (tbc).', CAST(N'2019-11-12' AS Date), N'Consulting Project', 3)
GO
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([Department])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Department] FOREIGN KEY([Department])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Department]
GO
USE [master]
GO
ALTER DATABASE [PE_PRN212_24SumB5] SET  READ_WRITE 
GO
