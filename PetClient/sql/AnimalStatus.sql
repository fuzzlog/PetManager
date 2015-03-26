USE [AnimalsDB]
GO

/****** Object:  Table [dbo].[AnimalStatus]    Script Date: 3/26/2015 12:18:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AnimalStatus](
	[AnimalStatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](32) NOT NULL,
 CONSTRAINT [PK_AnimalStatus] PRIMARY KEY CLUSTERED 
(
	[AnimalStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


INSERT INTO AnimalStatus(StatusName) VALUES('Deployed')
INSERT INTO AnimalStatus(StatusName) VALUES('Training')
INSERT INTO AnimalStatus(StatusName) VALUES('On Leave')
INSERT INTO AnimalStatus(StatusName) VALUES('Ready To Deploy')
INSERT INTO AnimalStatus(StatusName) VALUES('Deceased')
INSERT INTO AnimalStatus(StatusName) VALUES('Just Arrived')
GO


