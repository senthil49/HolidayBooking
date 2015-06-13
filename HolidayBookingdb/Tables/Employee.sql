﻿CREATE TABLE [crud].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [nvarchar](max) NOT NULL,
	[DateOfJoining] [date] NULL,
	[HolidaysEntitled] [int] NULL,
	[Dormant] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO