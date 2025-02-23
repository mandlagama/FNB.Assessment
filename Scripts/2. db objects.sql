USE [MoneyExchange]
GO
/****** Object:  Table [dbo].[Coin]    Script Date: 2025/02/23 10:16:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coin](
	[CoinId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[RandValue] [money] NOT NULL,
	[CreatedById] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[ModifiedById] [int] NULL,
	[ModifiedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_Coin] PRIMARY KEY CLUSTERED 
(
	[CoinId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoinStock]    Script Date: 2025/02/23 10:16:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoinStock](
	[CoinStockId] [int] IDENTITY(1,1) NOT NULL,
	[CoinId] [smallint] NOT NULL,
	[Available] [bigint] NOT NULL,
	[CreatedById] [int] NULL,
	[CreatedOn] [datetime2](7) NULL,
	[ModifiedById] [int] NULL,
	[ModifiedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_CoinStock] PRIMARY KEY CLUSTERED 
(
	[CoinStockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2025/02/23 10:16:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](20) NOT NULL,
	[Lastname] [varchar](20) NOT NULL,
	[CreatedById] [int] NULL,
	[CreatedOn] [datetime2](7) NULL,
	[ModifiedById] [int] NULL,
	[ModifiedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Coin] ON 
GO
INSERT [dbo].[Coin] ([CoinId], [Name], [RandValue], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (1, N'5c', 0.0500, 1, CAST(N'2025-02-22T06:55:46.9200000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Coin] ([CoinId], [Name], [RandValue], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (2, N'10c', 0.1000, 1, CAST(N'2025-02-22T06:59:18.7500000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Coin] ([CoinId], [Name], [RandValue], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (3, N'20c', 0.2000, 1, CAST(N'2025-02-22T07:00:23.4866667' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Coin] ([CoinId], [Name], [RandValue], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (4, N'50c', 0.5000, 1, CAST(N'2025-02-22T07:01:12.5533333' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Coin] ([CoinId], [Name], [RandValue], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (5, N'R1', 1.0000, 1, CAST(N'2025-02-22T07:02:02.4766667' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Coin] ([CoinId], [Name], [RandValue], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (6, N'R2', 2.0000, 1, CAST(N'2025-02-22T07:03:06.2833333' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Coin] ([CoinId], [Name], [RandValue], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (7, N'R5', 5.0000, 1, CAST(N'2025-02-22T07:05:11.1766667' AS DateTime2), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Coin] OFF
GO
SET IDENTITY_INSERT [dbo].[CoinStock] ON 
GO
INSERT [dbo].[CoinStock] ([CoinStockId], [CoinId], [Available], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (1, 6, 18, 1, CAST(N'2025-02-22T08:19:36.1000000' AS DateTime2), 1, CAST(N'2025-02-23T10:02:55.9033333' AS DateTime2))
GO
INSERT [dbo].[CoinStock] ([CoinStockId], [CoinId], [Available], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (2, 7, 16, 1, CAST(N'2025-02-22T08:22:08.7100000' AS DateTime2), 1, CAST(N'2025-02-23T10:02:55.8833333' AS DateTime2))
GO
INSERT [dbo].[CoinStock] ([CoinStockId], [CoinId], [Available], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (3, 1, 18, 1, CAST(N'2025-02-22T08:22:20.3300000' AS DateTime2), 1, CAST(N'2025-02-23T10:02:55.9200000' AS DateTime2))
GO
INSERT [dbo].[CoinStock] ([CoinStockId], [CoinId], [Available], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (4, 2, 20, 1, CAST(N'2025-02-22T08:22:23.9000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[CoinStock] ([CoinStockId], [CoinId], [Available], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (5, 3, 18, 1, CAST(N'2025-02-22T08:22:27.7400000' AS DateTime2), 1, CAST(N'2025-02-23T10:02:55.9133333' AS DateTime2))
GO
INSERT [dbo].[CoinStock] ([CoinStockId], [CoinId], [Available], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (6, 5, 18, 1, CAST(N'2025-02-22T08:22:30.8933333' AS DateTime2), 1, CAST(N'2025-02-23T10:02:55.9066667' AS DateTime2))
GO
INSERT [dbo].[CoinStock] ([CoinStockId], [CoinId], [Available], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (7, 4, 18, 1, CAST(N'2025-02-22T08:22:35.1333333' AS DateTime2), 1, CAST(N'2025-02-23T10:02:55.9100000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[CoinStock] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [Firstname], [Lastname], [CreatedById], [CreatedOn], [ModifiedById], [ModifiedOn]) VALUES (1, N'System', N'User', NULL, CAST(N'2025-02-22T06:50:17.4466667' AS DateTime2), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Coin] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[CoinStock] ADD  DEFAULT ((1)) FOR [CreatedById]
GO
ALTER TABLE [dbo].[CoinStock] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Coin]  WITH CHECK ADD  CONSTRAINT [FK_Coin_User] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Coin] CHECK CONSTRAINT [FK_Coin_User]
GO
ALTER TABLE [dbo].[CoinStock]  WITH CHECK ADD  CONSTRAINT [FK_CoinStock_Coin] FOREIGN KEY([CoinId])
REFERENCES [dbo].[Coin] ([CoinId])
GO
ALTER TABLE [dbo].[CoinStock] CHECK CONSTRAINT [FK_CoinStock_Coin]
GO
/****** Object:  StoredProcedure [dbo].[spGetCoinByRandValue]    Script Date: 2025/02/23 10:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetCoinByRandValue] 
@RandValue MONEY
AS
BEGIN
	SELECT C.[CoinId]
      , C.[Name]
      , C.[RandValue]
      , C.[CreatedById]
      , C.[CreatedOn]
      , C.[ModifiedById]
      , C.[ModifiedOn]
	FROM [dbo].[Coin] C
	WHERE C.[RandValue] = @RandValue
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCoinNameByRandValue]    Script Date: 2025/02/23 10:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetCoinNameByRandValue] 
@RandValue MONEY
AS
BEGIN
	SELECT C.[Name]
	FROM [dbo].[Coin] C
	WHERE C.[RandValue] = @RandValue
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCoinStockByCoinId]    Script Date: 2025/02/23 10:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetCoinStockByCoinId]
@CoinId SMALLINT
AS
BEGIN
	SELECT [Available]
	FROM [dbo].[CoinStock]
	WHERE [CoinId] = @CoinId
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCoinStockByRandValue]    Script Date: 2025/02/23 10:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetCoinStockByRandValue]
@RandValue MONEY
AS
BEGIN
	SELECT CS.[Available]
	FROM [dbo].[CoinStock] CS
	INNER JOIN [dbo].[Coin] C ON CS.CoinId = C.CoinId
	WHERE C.[RandValue] = @RandValue
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertOrUpdateCoinStock]    Script Date: 2025/02/23 10:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spInsertOrUpdateCoinStock] 
	@CoinId SMALLINT,
	@Available BIGINT 
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM [dbo].[CoinStock] WHERE [CoinId] = @CoinId)
	BEGIN

		INSERT INTO [dbo].[CoinStock]
           ([CoinId]
           ,[Available])
		VALUES
           (@CoinId
           ,@Available)
	END
	ELSE
	BEGIN
		UPDATE [dbo].[CoinStock]
		SET	[Available] = @Available
			,[ModifiedById] = 1--System user
			,[ModifiedOn] = GETDATE()
		 WHERE [CoinId] = @CoinId
	END
END
GO