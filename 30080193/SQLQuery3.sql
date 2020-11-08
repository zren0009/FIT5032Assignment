CREATE TABLE [dbo].[Locations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	 [Name] VARCHAR(MAX) NOT NULL,
	 [Description] VARCHAR(MAX) NOT NULL,
	 [Latitude] NUMERIC(10, 8) NOT NULL,
	 [Longitude] NUMERIC(11, 8) NOT NULL,
	CONSTRAINT CK_Latitude CHECK (Latitude >= -90 AND Latitude <= 90),
	CONSTRAINT CK_Longtitude CHECK (Longitude >= -180 AND Longitude <= 180)
)

CREATE TABLE [dbo].[Bookings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserId] nvarchar(450) NOT NULL,
	[LocationId] INT NOT NULL,
	[Email] nvarchar(max) not null,
	[FirstName] nvarchar(max) not null,
	[LastName] nvarchar(max) not null,
	[BookingDate] date not null,
	[BookingTime] time not null,
	[Bookinghours] int not null,
	foreign key (LocationId) references Locations(Id),
	constraint UC_userdate unique (UserId,BookingDate)
)

create table [dbo].[ratings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[BookingId] INT NOT NULL,
	[Rating] float not null,
	[Comment] nvarchar(max) not null,
	foreign key (BookingId) references Bookings(Id),
	constraint UC_booking unique(BookingId)
)