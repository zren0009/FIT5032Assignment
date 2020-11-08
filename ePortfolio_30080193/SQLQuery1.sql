﻿CREATE TABLE [dbo].[Location]
(
[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
 [Name] VARCHAR(MAX) NOT NULL,
 [Description] VARCHAR(MAX) NOT NULL,
 [Latitude] NUMERIC(10, 8) NOT NULL,
 [Longitude] NUMERIC(11, 8) NOT NULL,
CONSTRAINT CK_Latitude CHECK (Latitude >= -90 AND Latitude <= 90),
CONSTRAINT CK_Longtitude CHECK (Longitude >= -180 AND Longitude <=
180)
);

INSERT INTO [dbo].[Location] ([Name], [Description], [Latitude],
[Longitude]) VALUES (N'Monash University', N'Caulfield Campus', CAST(-
37.87682300 AS Decimal(10, 8)), CAST(145.04583700 AS Decimal(11, 8)));
INSERT INTO [dbo].[Location] ([Name], [Description], [Latitude],
[Longitude]) VALUES (N'Monash University', N'Clayton Campus', CAST(-
37.91500000 AS Decimal(10, 8)), CAST(145.13000000 AS Decimal(11, 8)));

CREATE TABLE [dbo].[Booking]
(
 [Id] INT IDENTITY (1, 1) NOT NULL,
 [StudentId] INT NOT NULL,
 [Start] DATETIME NOT NULL,
 [Hours] FLOAT NOT NULL,
 PRIMARY KEY CLUSTERED ([Id] ASC),
 FOREIGN KEY (StudentId) REFERENCES Students(Id)
);