USE [TokoDB]
GO

/****** Object:  Table [dbo].[Barang]    Script Date: 03/08/2023 21.17.16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Barang](
	[IdBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NULL,
	[HargaBarang] [numeric](18, 0) NULL,
	[QtyBarang] [numeric](18, 1) NULL,
	[Operator] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


