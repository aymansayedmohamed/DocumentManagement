USE [master]
GO
/****** Object:  Database [DocumentManagement]    Script Date: 4/1/2019 9:10:10 AM ******/
CREATE DATABASE [DocumentManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DocumentManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER_A\MSSQL\DATA\DocumentManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DocumentManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER_A\MSSQL\DATA\DocumentManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DocumentManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DocumentManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DocumentManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DocumentManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DocumentManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DocumentManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DocumentManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [DocumentManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DocumentManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DocumentManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DocumentManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DocumentManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DocumentManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DocumentManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DocumentManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DocumentManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DocumentManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DocumentManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DocumentManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DocumentManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DocumentManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DocumentManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DocumentManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DocumentManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DocumentManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DocumentManagement] SET  MULTI_USER 
GO
ALTER DATABASE [DocumentManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DocumentManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DocumentManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DocumentManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DocumentManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DocumentManagement]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 4/1/2019 9:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/1/2019 9:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/1/2019 9:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/1/2019 9:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/1/2019 9:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/1/2019 9:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 4/1/2019 9:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[DocumentID] [uniqueidentifier] NOT NULL,
	[UploadDate] [datetime] NULL,
	[LastAccessedDate] [datetime] NULL,
	[UploadUserId] [nvarchar](128) NULL,
	[DocumentSize] [int] NULL,
	[DocumentName] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[DocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201903291743222_InitialCreate', N'DocumentManagementAPIs.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5CDB6EE436127D5F60FF41D05376E1B47CC90C668D7602A76DEF1A195F30ED09F236604BECB63012A588946363912FDB877C527E618B1275E345976EB9BB1D0C306891C553C562912C168BFEF37F7F4C7F780E03EB0927D48FC8997D3439B42D4CDCC8F3C9EACC4ED9F2DB0FF60FDFFFFD6FD34B2F7CB67E2EE84E381DB424F4CC7E642C3E751CEA3EE210D149E8BB4944A3259BB851E8202F728E0F0FFFE51C1D3918206CC0B2ACE9A794303FC4D9077CCE22E2E298A528B8893C1C50510E35F30CD5BA4521A63172F1997D11B9698809BB4104AD30FF757E7F4D277943DB3A0F7C0442CD71B0B42D4448C41003914F3F533C67494456F3180A50F0F01263A05BA28062D195D38ABC6FAF0E8F79AF9CAA6101E5A69445E140C0A313A126476EBE96B2ED528DA0C84B50387BE1BDCE9479665F7B382BFA1405A00099E1E92C4838F1997D53B238A7F12D6693A2E12487BC4A00EEB728F93AA9231E58BDDB1D9466753C39E4FF0EAC591AB034C16704A72C41C181759F2E02DFFD09BF3C445F31393B395A2C4F3EBC7B8FBC93F7DFE19377F59E425F81AE510045F74914E30464C3CBB2FFB6E534DB3972C3B259AD4DAE15B0259821B675839E3F62B2628F30778E3FD8D695FF8CBDA24418D767E2C38482462C49E1F3360D02B4087059EFB4F2E4FFB7703D7EF77E14AEB7E8C95F65432FF1878993C0BCFA8483AC963EFA713EBD1AE3FD45905D2551C8BF9BF695D77E994769E2F2CE4446920794AC306B4A37752AE3ED65D21C6A7CB32E50F7DFB4B9A4AA796B497987D69909058B6DCF8642DED7E5DBDBE2CEE318062F332DAE9136836BDDB72612D081A527AF0CEAA8AF4111E8E85F797DBC0C911F8CB040F6E0026ECAD24F425CF6F2C708CC1191C132DF234A617DF0FE83E8638BE8F07304D1E7D84D1330DB394361FCEADCEE1F23826FD370C167C3F6788D36340FBF4557C86551724978AB8DF13E46EED7286597C4BB400C7F666E01C83F1FFCB03FC028E29CBB2EA6F40A8C197BB308BCF002F09AB093E3C1707CADDAB583320B901FEA3D146955FD5290565E8A9E42F1540C643A6FA54DD48FD1CA27FD442D48CDA2E6149DA20AB2A1A272B07E920A4AB3A01941A79C39D568FE5F3642E33B8019ECFE7B809B6DDEA6B5A0A6C639AC90F8DF98E0049631EF1E318613528D409F756317CE42367C9CE9ABEF4D19A79F51908ECD6AADD9902D02E3CF860C76FF67432626143FF91EF74A7A1C8B0A6280EF45AF3F7175CF3949B26D4F874637B7CD7C3B6B8069BA9C531AB97E360B34013111CE68CA0F3E9CD51DDBC87B23C747A06360E83EDFF2A004FA66CB4675472E708019B6CEDD3C603843D4459EAA46E8903740B06247D50856C5499AC2FD53E109968E13DE08F143108599EA13A64E0B9FB87E8C824E2D492D7B6E61BCEF250FB9E602C79870869D9AE8C35C1F16E102947CA441E9D2D0D4A9595CBB211ABC56D39877B9B0D5B82BD18AADD86487EF6CB04BE1BFBD8A61B66B6C0BC6D9AE923E0218437CBB30507156E96B00F2C165DF0C543A31190C54B8545B31D0A6C67660A04D95BC3903CD8FA87DC75F3AAFEE9B79360FCADBDFD65BD5B503DB6CE863CF4C33F73DA10D83163851CDF362C12BF133D31CCE404E713EA3C2D5954D8483CF316B866C2A7F57EB873AED20B211B5015686D6012A2E07152065420D10AE88E5B54A27BC8801B045DCAD1556ACFD126CCD0654ECFA25698DD07C952A1B67AFD347D9B3D21A1423EF7558A8E1680C425EBC9A1DEFA114535C56554C1F5F7888375CEB98188C16057578AE0625159D195D4B8569766B49E7900D71C936D292E43E19B4547466742D091BED5692C62918E0166CA4A2E6163ED2642B221DE56E53D64D9D3C8D4A144C1D43BED5F406C5B14F56B5FC2B5162CDF3E4ABD9B7F3E1A948618EE1B8549391544A5B726251825658AA05D620E9959F507681185A201EE79979A142A6DD5B0DCB7FC1B2BE7DAA8358EC030535FF9DB768BFD26F6CBBAA5F22E0AEA0B3BC65D66FAC31057D738BA7C6A100259A20FE2C0AD290987D2D73EBFC2AAFDE3E2F5111A68E24BFE24B298A533CDEE628F41A23757E8C3F5EA557B3FE9899214C9A2F7CD2BAEE4D7EAA19A5085BD5514CA1AC9D8DA1C9BD5977DC642772F8B07522BCCE6C13992B7500513410A396FCA080D5EAFAA336F353EA98CD9AFE8852124A1D52AA1A20653DD5A42164BD622D3C8346F514FD39A8C9257574B5B63FB226CDA40EADA95E035B23B35CD71F5593895207D654F7C7AED252E4F5748FF733E3D1668C0D2D3F086FB6A319305E67711C6743ACDDF7D7816AC503B1C48DBE0226CAF7D2B08CA7C1310C2B0F856C6658060CF37AD4B8346F2E47AD37FD66CCC64D7863C96FCB0430E30D33DF573512E55C289394DCCBF3A1740E9C8A3359F7E31CE5909693D856A146D8EE5F28C3E184134CE6BF06B3C0C77C712F08C0E2FC25A62CCFFEB08F0F8F8EA5473DFBF3C0C6A1D40B34675AD32B9BE6986D21918B3CA1C47D44899A56B1C123940A5489585F130F3F9FD9FFCD5A9D66C10FFE2B2B3EB0AEE967E2FF9A42C5439262EB77354D749CA4FC1ECF404A417F7F13EF2BFAABFCFA972F79D303EB2E81E9746A1D4A8A5E67F89BAF2E06499337DD409AB5DF62BCDDD9D678D2A0459566CBFA2F18163E1BE5F54221E537217AFEC750D1B42F143642D4BC42180B6F14159A5E19AC83657C61E0C127CB5E180CEBACFEC5C13AA2195F1BF8643898FCD6A0FF3254B4DCE13EA4393B6D6349CAF4DC99ABBD51E2E6AEF72625A57BA389AEA66D0F801B35357B3317E58DA53C8FB6756A329A47C3DEA5DDBF7A1AF3BE642E574EFB6E1396B799A3DC72E3F4974A4DDE83643A4D72D0EE1390B76D6BA660F09E67710E4B33DE336313DBFCEE9389B76D6CA600F19E1BDBA094E13DB3B55DED9F3BB6B4DE5BE8CE1380D55C26C3A58E2E8ADC95E09B87DCE1F8BF88C008728F327F97A9CF283331AB8CC5C8B022313335A7B2C98C9589A3F05528DAD90EEBABD8F05B3B2B68DAD91A1240DB788BF5BF95B7A069E76D48ABDC456AB236B151972EDEB18EB5E557BDA554E4464F3A32DFBB7CD6D61BFAB794793C8A521AB3C770BBFC76128D4751C99853674062B17A510C7B67ED6F3DC2FE4DFD5505C1FFF223C16E63D72C69AEC9322A366F49A282448AD0DC60863CD852CF13E62F91CBA09A07A0B387E559508F5F832CB0774DEE5216A70CBA8CC345D008787127A08D7F963DDD94797A17F32F3A4617404C9F07EEEFC88FA91F78A5DC579A989001827B1722DCCBC792F1B0EFEAA544BA8D484F20A1BED2297AC0611C0018BD2373F484D7910DCCEF235E21F7A58A009A40BA07A2A9F6E9858F56090AA9C0A8DAC327D8B0173E7FFF7FC5C9DDACF2540000, N'6.2.0-61023')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e30cf1bb-1781-4252-ac1d-2115a79a3fa3', N'1')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e30cf1bb-1781-4252-ac1d-2115a79a3fa3', N'TEST@TEST.TEST', 0, N'AJZoZFhBKxPUSPTCYlTINznSCLELBOy7FIv+413OVAo0PCusR9Qnfyz7tfy3xwTTxg==', N'aa1c25f1-541d-4629-8c90-663c312b0548', NULL, 0, 0, NULL, 0, 0, N'TEST@TEST.TEST')
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/1/2019 9:10:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 4/1/2019 9:10:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 4/1/2019 9:10:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 4/1/2019 9:10:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 4/1/2019 9:10:11 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/1/2019 9:10:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Documents] ADD  CONSTRAINT [DF_Documents_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_AspNetUsers] FOREIGN KEY([UploadUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_AspNetUsers]
GO
USE [master]
GO
ALTER DATABASE [DocumentManagement] SET  READ_WRITE 
GO
