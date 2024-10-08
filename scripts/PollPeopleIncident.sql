USE [LetPollPeopleDb]
GO
/****** Object:  Table [dbo].[Option]    Script Date: 2024/08/09 11:50:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Option](
	[OptionId] [int] IDENTITY(1,1) NOT NULL,
	[OptionText] [varchar](100) NOT NULL,
	[QuestionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 2024/08/09 11:50:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [varchar](250) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2024/08/09 11:50:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2024/08/09 11:50:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](256) NOT NULL,
	[FirstName] [varchar](150) NULL,
	[LastName] [varchar](150) NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 2024/08/09 11:50:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserVote]    Script Date: 2024/08/09 11:50:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserVote](
	[UserVoteId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[OptionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserVoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Option] ON 

INSERT [dbo].[Option] ([OptionId], [OptionText], [QuestionId]) VALUES (13, N'Rocky road', 8)
INSERT [dbo].[Option] ([OptionId], [OptionText], [QuestionId]) VALUES (14, N'Caramel', 8)
INSERT [dbo].[Option] ([OptionId], [OptionText], [QuestionId]) VALUES (15, N'Vanilla', 8)
INSERT [dbo].[Option] ([OptionId], [OptionText], [QuestionId]) VALUES (16, N'Strawberry', 8)
INSERT [dbo].[Option] ([OptionId], [OptionText], [QuestionId]) VALUES (17, N'Hot Dog', 9)
INSERT [dbo].[Option] ([OptionId], [OptionText], [QuestionId]) VALUES (18, N'Burger', 9)
INSERT [dbo].[Option] ([OptionId], [OptionText], [QuestionId]) VALUES (19, N'Pizza', 9)
SET IDENTITY_INSERT [dbo].[Option] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([QuestionId], [QuestionText], [UserId]) VALUES (8, N'Which is your preferred flavour of ice-cream?', 8)
INSERT [dbo].[Question] ([QuestionId], [QuestionText], [UserId]) VALUES (9, N'Which food do you prefer?', 8)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'SystemAdmin')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Username], [Password], [FirstName], [LastName], [IsActive]) VALUES (8, N'Mlando', N'75ee8d4458dea85b62bda80306c89aa859d4903660de735e6d96b74cab411f97', N'Mlando', N'Sikhosana Khoza', 1)
INSERT [dbo].[User] ([UserId], [Username], [Password], [FirstName], [LastName], [IsActive]) VALUES (9, N'Areezy', N'917d7ef28d528aecdaa3f883965b6109170e7ea848561044a6f7443fb134b2a7', N'Aron', N'Mazel', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([UserRoleId], [UserId], [RoleId]) VALUES (7, 8, 2)
INSERT [dbo].[UserRole] ([UserRoleId], [UserId], [RoleId]) VALUES (8, 9, 2)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[UserVote] ON 

INSERT [dbo].[UserVote] ([UserVoteId], [UserId], [QuestionId], [OptionId]) VALUES (6, 8, 8, 16)
INSERT [dbo].[UserVote] ([UserVoteId], [UserId], [QuestionId], [OptionId]) VALUES (7, 8, 9, 17)
INSERT [dbo].[UserVote] ([UserVoteId], [UserId], [QuestionId], [OptionId]) VALUES (8, 9, 8, 16)
INSERT [dbo].[UserVote] ([UserVoteId], [UserId], [QuestionId], [OptionId]) VALUES (9, 9, 9, 19)
SET IDENTITY_INSERT [dbo].[UserVote] OFF
GO
ALTER TABLE [dbo].[Option]  WITH CHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserVote]  WITH CHECK ADD FOREIGN KEY([OptionId])
REFERENCES [dbo].[Option] ([OptionId])
GO
ALTER TABLE [dbo].[UserVote]  WITH CHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([QuestionId])
GO
ALTER TABLE [dbo].[UserVote]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
