USE [AnimalsDB]
GO

/****** Object:  Table [dbo].[Animals]    Script Date: 3/26/2015 12:16:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Animals](
	[AnimalsID] [int] IDENTITY(1,1) NOT NULL,
	[Moniker] [varchar](255) NULL,
	[PetId] [int] NULL,
	[City] [varchar](255) NULL,
	[Located] [datetime] NULL,
	[AnimalStatusID] [int] NOT NULL CONSTRAINT [DF_Animals_AnimalStatusID]  DEFAULT ((6)),
PRIMARY KEY CLUSTERED 
(
	[AnimalsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Animals]  WITH CHECK ADD  CONSTRAINT [FK_Animals_AnimalStatus] FOREIGN KEY([AnimalStatusID])
REFERENCES [dbo].[AnimalStatus] ([AnimalStatusID])
GO

ALTER TABLE [dbo].[Animals] CHECK CONSTRAINT [FK_Animals_AnimalStatus]
GO



