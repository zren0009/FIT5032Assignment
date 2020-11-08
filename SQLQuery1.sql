DROP TABLE [dbo].[Students];
GO
CREATE TABLE [dbo].[Students] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[FirstName] nvarchar(max) NOT NULL,
	[LastName] nvarchar(max) NOT NULL,
	[UserId] nvarchar(max) NOT NULL,
	[ContactPhone] nvarchar(max) NOT NULL,
	[Address] nvarchar(max),
	[Email] nvarchar(max) NOT NULL,
	[Nationality] nvarchar(max) NOT NULL,
	[UpdateTime] Date NOT NULL,
	PRIMARY KEY(Id)
);
GO

DROP TABLE [dbo].[Tutors];
GO
CREATE TABLE [dbo].[Tutors] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[FirstName] nvarchar(max) NOT NULL,
	[LastName] nvarchar(max) NOT NULL,
	[UserId] nvarchar(max) NOT NULL,
	[ContactPhone] nvarchar(max) NOT NULL,
	[Address] nvarchar(max),
	[Email] nvarchar(max) NOT NULL,
	[Nationality] nvarchar(max) NOT NULL,
	[UpdateTime] Date NOT NULL,
	PRIMARY KEY(Id)
);
GO

DROP TABLE [dbo].[Faculty];
GO
CREATE TABLE [dbo].[Faculty] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(max) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	[UpdateTime] Date NOT NULL,
	PRIMARY KEY(Id)
);
GO

DROP TABLE [dbo].[Units];
GO
CREATE TABLE [dbo].[Units] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(max) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	[FacultyId] int NOT NULL,
	[UpdateTime] Date NOT NULL,
	PRIMARY KEY(Id),
	FOREIGN KEY (FacultyId) REFERENCES Faculty(Id)
);
GO

DROP TABLE [dbo].[Enrolment];
GO
CREATE TABLE [dbo].[Enrolment] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[StudentId] int NOT NULL,
	[UnitId] int NOT NULL,
	[Year] int NOT NULL,
	[Semester] int NOT NULL,
	[UpdateTime] Date NOT NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (StudentId) REFERENCES Students(Id),
	FOREIGN KEY (UnitId) REFERENCES Units(Id)
);
GO

DROP TABLE [dbo].[TutorUnit];
GO
CREATE TABLE [dbo].[TutorUnit] (
	[Id] int IDENTITY(1,1) NOT NULL,
	[TutorId] int NOT NULL,
	[UnitId] int NOT NULL,
	[Year] int NOT NULL,
	[Semester] int NOT NULL,
	[UpdateTime] Date NOT NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (TutorId) REFERENCES Tutors(Id),
	FOREIGN KEY (UnitId) REFERENCES Units(Id)
);
GO