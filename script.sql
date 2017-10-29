USE [Library]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 2017/10/29 9:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Bookname] [text] NOT NULL,
	[NumSpecial] [text] NULL,
	[NumBook] [text] NULL,
	[Author] [text] NULL,
	[Address] [text] NULL,
	[Price] [float] NULL,
	[Kind] [nchar](1) NULL,
	[Subject] [nchar](10) NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[I_Like]    Script Date: 2017/10/29 9:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[I_Like](
	[id] [int] NOT NULL,
	[bookid] [int] NOT NULL,
	[userid] [int] NOT NULL,
	[bookShelfId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_I_Like] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Judge]    Script Date: 2017/10/29 9:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Judge](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[JudgerId] [int] NOT NULL,
	[Judge] [int] NULL,
 CONSTRAINT [PK_Judge] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LendInfo]    Script Date: 2017/10/29 9:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LendInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[LendTime] [date] NULL,
	[ReturnTime] [date] NULL,
	[ContinueTimeLimit] [int] NULL,
	[ContinueTimesNow] [int] NULL,
 CONSTRAINT [PK_LendInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MyMistakes]    Script Date: 2017/10/29 9:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyMistakes](
	[id] [int] NOT NULL,
	[bookid] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[WrongKind] [int] NOT NULL,
	[WrongNote] [nchar](30) NULL,
	[WrongPay] [real] NULL,
 CONSTRAINT [PK_MyMistakes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MyShelf]    Script Date: 2017/10/29 9:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyShelf](
	[id] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[shelfName] [nchar](10) NOT NULL,
	[bookAmount] [int] NULL,
 CONSTRAINT [PK_MyShelf] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 2017/10/29 9:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[People](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[number] [nchar](10) NOT NULL,
	[Name] [nchar](20) NOT NULL,
	[Sex] [char](1) NOT NULL,
	[Email] [nchar](20) NOT NULL,
	[PhoneNum] [nchar](20) NULL,
	[IDCardNum] [nchar](30) NOT NULL,
	[Birthday] [nchar](20) NULL,
	[Password] [nchar](10) NULL,
	[BeginTime] [nchar](20) NOT NULL,
	[EndTime] [nchar](20) NOT NULL,
	[Kind] [nchar](10) NOT NULL,
	[Workplace] [nchar](20) NULL,
	[LendMax] [int] NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recommend]    Script Date: 2017/10/29 9:23:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recommend](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Recommenderid] [int] NOT NULL,
	[bookname] [nchar](50) NOT NULL,
	[authorName] [nchar](50) NOT NULL,
	[publishInfo] [nchar](50) NOT NULL,
	[RecommenDate] [nchar](30) NOT NULL,
	[result] [int] NULL,
	[note] [nchar](30) NULL,
	[managerId] [int] NULL,
 CONSTRAINT [PK_Recommend] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Books] FOREIGN KEY([id])
REFERENCES [dbo].[Books] ([id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Books]
GO
ALTER TABLE [dbo].[I_Like]  WITH CHECK ADD  CONSTRAINT [FK_I_Like_Books] FOREIGN KEY([id])
REFERENCES [dbo].[Books] ([id])
GO
ALTER TABLE [dbo].[I_Like] CHECK CONSTRAINT [FK_I_Like_Books]
GO
ALTER TABLE [dbo].[I_Like]  WITH CHECK ADD  CONSTRAINT [FK_I_Like_MyShelf] FOREIGN KEY([id])
REFERENCES [dbo].[MyShelf] ([id])
GO
ALTER TABLE [dbo].[I_Like] CHECK CONSTRAINT [FK_I_Like_MyShelf]
GO
ALTER TABLE [dbo].[I_Like]  WITH CHECK ADD  CONSTRAINT [FK_I_Like_People] FOREIGN KEY([id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[I_Like] CHECK CONSTRAINT [FK_I_Like_People]
GO
ALTER TABLE [dbo].[Judge]  WITH CHECK ADD  CONSTRAINT [FK_Judge_Books] FOREIGN KEY([id])
REFERENCES [dbo].[Books] ([id])
GO
ALTER TABLE [dbo].[Judge] CHECK CONSTRAINT [FK_Judge_Books]
GO
ALTER TABLE [dbo].[Judge]  WITH CHECK ADD  CONSTRAINT [FK_Judge_People] FOREIGN KEY([id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Judge] CHECK CONSTRAINT [FK_Judge_People]
GO
ALTER TABLE [dbo].[LendInfo]  WITH CHECK ADD  CONSTRAINT [FK_LendInfo_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([id])
GO
ALTER TABLE [dbo].[LendInfo] CHECK CONSTRAINT [FK_LendInfo_Books]
GO
ALTER TABLE [dbo].[LendInfo]  WITH CHECK ADD  CONSTRAINT [FK_LendInfo_LendInfo1] FOREIGN KEY([id])
REFERENCES [dbo].[LendInfo] ([id])
GO
ALTER TABLE [dbo].[LendInfo] CHECK CONSTRAINT [FK_LendInfo_LendInfo1]
GO
ALTER TABLE [dbo].[LendInfo]  WITH CHECK ADD  CONSTRAINT [FK_LendInfo_People] FOREIGN KEY([UserId])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[LendInfo] CHECK CONSTRAINT [FK_LendInfo_People]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_People] FOREIGN KEY([id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_People]
GO
ALTER TABLE [dbo].[Recommend]  WITH CHECK ADD  CONSTRAINT [FK_Recommend_People] FOREIGN KEY([id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Recommend] CHECK CONSTRAINT [FK_Recommend_People]
GO
ALTER TABLE [dbo].[Recommend]  WITH CHECK ADD  CONSTRAINT [FK_Recommend_People1] FOREIGN KEY([id])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Recommend] CHECK CONSTRAINT [FK_Recommend_People1]
GO
