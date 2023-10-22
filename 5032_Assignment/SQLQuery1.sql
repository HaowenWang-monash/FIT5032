CREATE TABLE [dbo].[Appointment]
(
	 [Id] INT PRIMARY KEY IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [AppointmentTime] DATETIME NOT NULL
)