USE [CVManagSystem]
GO

/****** Object:  Table [dbo].[ApplicantDetails]    Script Date: 10/3/2016 2:45:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ApplicantDetails](
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[InterestAnimalProduction] [bit] NULL,
	[InterestBusiness] [bit] NULL,
	[InterestHr] [bit] NULL,
	[InterestIt] [bit] NULL,
	[InterestJura] [bit] NULL,
	[InterestEconomy] [bit] NULL,
	[InterestPlanets] [bit] NULL,
	[InterestOthers] [bit] NULL,
	[Status] [nvarchar](max) NULL,
	[LinkedInUrl] [nvarchar](max) NULL,
	[CV] [nvarchar](max) NULL,
	[AcceptTerms] [bit] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ApplicantDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


