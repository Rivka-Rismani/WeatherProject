USE [wether]
GO
/****** Object:  Table [dbo].[FavoriteCities]    Script Date: 07/12/2021 08:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoriteCities](
	[CityId] [bigint] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_FavoriteCities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FavoriteCities] ON 

INSERT [dbo].[FavoriteCities] ([CityId], [CityName]) VALUES (1, N'Tel Aviv')
INSERT [dbo].[FavoriteCities] ([CityId], [CityName]) VALUES (2, N'Ramat Gan')
INSERT [dbo].[FavoriteCities] ([CityId], [CityName]) VALUES (3, N'Kfar Saba')
INSERT [dbo].[FavoriteCities] ([CityId], [CityName]) VALUES (4, N'Acre')
INSERT [dbo].[FavoriteCities] ([CityId], [CityName]) VALUES (5, N'Raanana')
INSERT [dbo].[FavoriteCities] ([CityId], [CityName]) VALUES (6, N'Jerusalem')
INSERT [dbo].[FavoriteCities] ([CityId], [CityName]) VALUES (7, N'Athens')
SET IDENTITY_INSERT [dbo].[FavoriteCities] OFF
GO
