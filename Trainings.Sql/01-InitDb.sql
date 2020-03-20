USE [Trainings]
GO

CREATE TABLE [User] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [RoleId] tinyint NOT NULL,
  [FirstName] varchar(40) NOT NULL,
  [LastName] varchar(40) NOT NULL,
  [Email] varchar(100) UNIQUE NOT NULL,
  [HashedPassword] varchar(100) NOT NULL,
  [RoleName] varchar(30) NOT NULL
)
GO

CREATE TABLE [PersonalInformation] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [Height] float(24),
  [Weight] float(24),
  [Age] tinyint,
  [Sex] bit,
  [BodyFatRate] float(24),
  [ProfileLevel] varchar(30),
  [Bmi] float(24)
)
GO

CREATE TABLE [UserPreference] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [TrainingTypeId] smallint NOT NULL,
  [TrainingDuration] tinyint,
  [BodyWeightWorkout] bit
)
GO

CREATE TABLE [TrainingFrequency] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserPreferenceId] int NOT NULL,
  [Monday] bit,
  [Tuesday] bit,
  [Wednesday] bit,
  [Thursday] bit,
  [Friday] bit,
  [Saturday] bit,
  [Sunday] bit
)
GO

CREATE TABLE [Lov] (
  [Id] smallint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [LovTypeId] smallint NOT NULL,
  [LovTypeName] varchar(30) NOT NULL,
  [Name] varchar(40) NOT NULL,
  [Description] varchar(500)
)
GO

CREATE TABLE [Log] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Date] datetime NOT NULL,
  [Level] varchar(30) NOT NULL,
  [Type] varchar(30) NOT NULL,
  [Action] varchar(30) NOT NULL
)
GO

CREATE TABLE [Training] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserPreferenceId] int NOT NULL,
  [CreationDate] datetime NOT NULL,
  [NbOfExercice] tinyint NOT NULL,
  [Duration] tinyint NOT NULL
)
GO

CREATE TABLE [Exercice] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [TrainingId] int NOT NULL,
  [ExerciceId] smallint NOT NULL,
  [NbOfSets] tinyint,
  [NbOfRepetitions] tinyint,
  [Duration] float,
  [RestDuration] float NOT NULL,
  [MuscleGroup] varchar(30) NOT NULL
)
GO

ALTER TABLE [PersonalInformation] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [UserPreference] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [TrainingFrequency] ADD FOREIGN KEY ([UserPreferenceId]) REFERENCES [UserPreference] ([Id])
GO

ALTER TABLE [UserPreference] ADD FOREIGN KEY ([TrainingTypeId]) REFERENCES [Lov] ([Id])
GO

ALTER TABLE [Training] ADD FOREIGN KEY ([UserPreferenceId]) REFERENCES [UserPreference] ([Id])
GO

ALTER TABLE [Exercice] ADD FOREIGN KEY ([ExerciceId]) REFERENCES [Lov] ([Id])
GO

ALTER TABLE [Exercice] ADD FOREIGN KEY ([TrainingId]) REFERENCES [Training] ([Id])
GO
