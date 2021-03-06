USE [LibraryManager]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 04/24/2014 06:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Super Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'Borrower')
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  Table [dbo].[Categories]    Script Date: 04/24/2014 06:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoriesId] [int] IDENTITY(1,1) NOT NULL,
	[CategoriesName] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[CategoriesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT [dbo].[Categories] ([CategoriesId], [CategoriesName], [IsDelete]) VALUES (1, N'All', 0)
INSERT [dbo].[Categories] ([CategoriesId], [CategoriesName], [IsDelete]) VALUES (2, N'Children books', 0)
INSERT [dbo].[Categories] ([CategoriesId], [CategoriesName], [IsDelete]) VALUES (3, N'Business books books', 0)
INSERT [dbo].[Categories] ([CategoriesId], [CategoriesName], [IsDelete]) VALUES (4, N'Literature books', 0)
INSERT [dbo].[Categories] ([CategoriesId], [CategoriesName], [IsDelete]) VALUES (5, N'Music books', 0)
INSERT [dbo].[Categories] ([CategoriesId], [CategoriesName], [IsDelete]) VALUES (6, N'Technology books', 0)
INSERT [dbo].[Categories] ([CategoriesId], [CategoriesName], [IsDelete]) VALUES (7, N'hai', 1)
INSERT [dbo].[Categories] ([CategoriesId], [CategoriesName], [IsDelete]) VALUES (8, N'131', 0)
SET IDENTITY_INSERT [dbo].[Categories] OFF
/****** Object:  Table [dbo].[Authors]    Script Date: 04/24/2014 06:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](150) NULL,
	[Address] [nvarchar](300) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Biography] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [Address], [PhoneNumber], [Biography], [IsDelete]) VALUES (1, N'Julia Donaldson', N'San francisco', N'213456789', N'', 0)
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [Address], [PhoneNumber], [Biography], [IsDelete]) VALUES (2, N'Beth Carswell', N'Los Angles', N'98765432', N'dsfsf', 0)
SET IDENTITY_INSERT [dbo].[Authors] OFF
/****** Object:  Table [dbo].[Books]    Script Date: 04/24/2014 06:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](max) NULL,
	[Price] [nvarchar](max) NULL,
	[CategoriesId] [int] NOT NULL,
	[Decription] [nvarchar](max) NULL,
	[DateUpdate] [datetime] NULL,
	[PageNumber] [nvarchar](max) NULL,
	[PictureName] [nvarchar](max) NULL,
	[NumberOfViews] [int] NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_CategoriesId] ON [dbo].[Books] 
(
	[CategoriesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON
INSERT [dbo].[Books] ([BookId], [BookName], [Price], [CategoriesId], [Decription], [DateUpdate], [PageNumber], [PictureName], [NumberOfViews], [IsDelete]) VALUES (1, N'The Gruffalo in Scots', N'50', 2, N'We don''t think there''s anyone, anywhere in the book-loving world who hasn''t heard of the Gruffalo.
                Julia Donaldson''s lovable and unforgettable creation has enchanted little ones for over a decade and now young Scottish
                readers can enjoy this very special edition of Julia''s tale starring the much-adored Gruffalo, now told in flowing Scots!
                The original story''s illustrations by Axel Scheffler help make this the perfect keepsake for any proud Scot!', CAST(0x0000A2FA00000000 AS DateTime), N'60', N'GRUS_childrenBook.jpg', 0, 0)
INSERT [dbo].[Books] ([BookId], [BookName], [Price], [CategoriesId], [Decription], [DateUpdate], [PageNumber], [PictureName], [NumberOfViews], [IsDelete]) VALUES (2, N'Old Macdonald Had a Zoo', N'10', 2, N'After winning the lottery, Old MacDonald decides to sell up his farm
                and buy a zoo with his winnings - but what will the old farm animals make of this? 
                With liftable flaps adding extra interaction to this brilliant twist on a well-known tale,
                the book hilariously reveals how the zoo animals picked off the farm animals one by one.
                From the talented mind of Curtis Jobling and the amazing illustrator Tom McLaughlin,
                this is a laugh-out-loud book for child and parent.', CAST(0x0000A2FA00000000 AS DateTime), N'20', N'OLM2.jpg', 1, 0)
INSERT [dbo].[Books] ([BookId], [BookName], [Price], [CategoriesId], [Decription], [DateUpdate], [PageNumber], [PictureName], [NumberOfViews], [IsDelete]) VALUES (3, N'Books Signed by Musicians', N'120', 5, N'Music is the soundtrack to our memories and one of life’s
                great pleasures. And the people who write, sing and play live a rollercoaster existence in the glare of the public eye.
                These stars suffer heartbreak and heartache, personal tragedies,
                drug and alcohol addiction, in-fighting and real fighting,
                financial woes despite earning a fortune, and the odd loneliness of life on the road.
                These books are fascinating reads and signed too.', CAST(0x00009D4500000000 AS DateTime), N'256', N'greendale-neil-young.jpg', 1, 0)
INSERT [dbo].[Books] ([BookId], [BookName], [Price], [CategoriesId], [Decription], [DateUpdate], [PageNumber], [PictureName], [NumberOfViews], [IsDelete]) VALUES (4, N'www', N'12', 2, N'wqer', CAST(0x0000A31800000000 AS DateTime), N'1', N'vsdf', 2, 1)
SET IDENTITY_INSERT [dbo].[Books] OFF
/****** Object:  Table [dbo].[Borrowers]    Script Date: 04/24/2014 06:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrowers](
	[UserName] [nvarchar](128) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[RoleId] [int] NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[IsMale] [bit] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Borrowers] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[Borrowers] 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[Borrowers] ([UserName], [Password], [Name], [Address], [PhoneNumber], [RoleId], [DateOfBirth], [IsMale], [Email], [IsDelete]) VALUES (N'Chinh', N'123', NULL, N'def', N'54321', 2, CAST(0x0000822D00000000 AS DateTime), 0, N'chinh@gmail.com', 0)
INSERT [dbo].[Borrowers] ([UserName], [Password], [Name], [Address], [PhoneNumber], [RoleId], [DateOfBirth], [IsMale], [Email], [IsDelete]) VALUES (N'Hue', N'123', NULL, N'abc', N'12345', 1, CAST(0x000083B300000000 AS DateTime), 1, N'duchuecntt@gmail.com', 0)
INSERT [dbo].[Borrowers] ([UserName], [Password], [Name], [Address], [PhoneNumber], [RoleId], [DateOfBirth], [IsMale], [Email], [IsDelete]) VALUES (N'Joshua', N'123', NULL, N'mno', N'98765', 3, CAST(0x000081B500000000 AS DateTime), 1, N'Joshua@gmail.com', 0)
/****** Object:  Table [dbo].[TakePartIns]    Script Date: 04/24/2014 06:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TakePartIns](
	[AuthorId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[Role] [nvarchar](50) NULL,
	[Position] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TakePartIns] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC,
	[BookId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AuthorId] ON [dbo].[TakePartIns] 
(
	[AuthorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BookId] ON [dbo].[TakePartIns] 
(
	[BookId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[TakePartIns] ([AuthorId], [BookId], [Role], [Position]) VALUES (1, 1, N'Writer', N'Main')
INSERT [dbo].[TakePartIns] ([AuthorId], [BookId], [Role], [Position]) VALUES (1, 2, N'Writer', N'Main')
INSERT [dbo].[TakePartIns] ([AuthorId], [BookId], [Role], [Position]) VALUES (2, 3, N'Writer', N'Main')
/****** Object:  Table [dbo].[BorrowerBooks]    Script Date: 04/24/2014 06:35:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowerBooks](
	[BookId] [int] NOT NULL,
	[UserName] [nvarchar](128) NOT NULL,
	[DateBorrow] [datetime] NOT NULL,
	[DateReturn] [datetime] NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.BorrowerBooks] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[UserName] ASC,
	[DateBorrow] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BookId] ON [dbo].[BorrowerBooks] 
(
	[BookId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[BorrowerBooks] 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[BorrowerBooks] ([BookId], [UserName], [DateBorrow], [DateReturn], [IsDelete]) VALUES (1, N'Chinh', CAST(0x0000A30B00000000 AS DateTime), NULL, 0)
INSERT [dbo].[BorrowerBooks] ([BookId], [UserName], [DateBorrow], [DateReturn], [IsDelete]) VALUES (1, N'Hue', CAST(0x0000A30100000000 AS DateTime), CAST(0x0000A30200000000 AS DateTime), 0)
/****** Object:  ForeignKey [FK_dbo.Books_dbo.Categories_CategoriesId]    Script Date: 04/24/2014 06:35:43 ******/
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Books_dbo.Categories_CategoriesId] FOREIGN KEY([CategoriesId])
REFERENCES [dbo].[Categories] ([CategoriesId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_dbo.Books_dbo.Categories_CategoriesId]
GO
/****** Object:  ForeignKey [FK_dbo.Borrowers_dbo.Roles_RoleId]    Script Date: 04/24/2014 06:35:43 ******/
ALTER TABLE [dbo].[Borrowers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Borrowers_dbo.Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Borrowers] CHECK CONSTRAINT [FK_dbo.Borrowers_dbo.Roles_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.TakePartIns_dbo.Authors_AuthorId]    Script Date: 04/24/2014 06:35:43 ******/
ALTER TABLE [dbo].[TakePartIns]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TakePartIns_dbo.Authors_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TakePartIns] CHECK CONSTRAINT [FK_dbo.TakePartIns_dbo.Authors_AuthorId]
GO
/****** Object:  ForeignKey [FK_dbo.TakePartIns_dbo.Books_BookId]    Script Date: 04/24/2014 06:35:43 ******/
ALTER TABLE [dbo].[TakePartIns]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TakePartIns_dbo.Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TakePartIns] CHECK CONSTRAINT [FK_dbo.TakePartIns_dbo.Books_BookId]
GO
/****** Object:  ForeignKey [FK_dbo.BorrowerBooks_dbo.Books_BookId]    Script Date: 04/24/2014 06:35:43 ******/
ALTER TABLE [dbo].[BorrowerBooks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BorrowerBooks_dbo.Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BorrowerBooks] CHECK CONSTRAINT [FK_dbo.BorrowerBooks_dbo.Books_BookId]
GO
/****** Object:  ForeignKey [FK_dbo.BorrowerBooks_dbo.Borrowers_UserName]    Script Date: 04/24/2014 06:35:43 ******/
ALTER TABLE [dbo].[BorrowerBooks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BorrowerBooks_dbo.Borrowers_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Borrowers] ([UserName])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BorrowerBooks] CHECK CONSTRAINT [FK_dbo.BorrowerBooks_dbo.Borrowers_UserName]
GO
