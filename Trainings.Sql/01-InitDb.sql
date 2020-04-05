CREATE TABLE [User] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [RoleCode] varchar(30) NOT NULL,
  [FirstName] varchar(40) NOT NULL,
  [LastName] varchar(40) NOT NULL,
  [Email] varchar(100) UNIQUE NOT NULL,
  [HashedPassword] varchar(100) NOT NULL,
  [HasFillInformation] bit NOT NULL,
  [CreationDate] datetime NOT NULL,
  [FillInformationDate] datetime
)
GO

CREATE TABLE [UserPreferences] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [GoalCode] varchar(40) NOT NULL,
  [TrainingTypeCode] varchar(40) NOT NULL,
  [TrainingDurationCode] varchar(40) NOT NULL,
  [EquipmentCode] varchar(40) NOT NULL
)
GO

CREATE TABLE [UserPhysicalInformation] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [Level] smallint NOT NULL,
  [Height] float(24) NOT NULL,
  [Weight] float(24) NOT NULL,
  [Age] tinyint NOT NULL,
  [Sex] bit NOT NULL,
  [BodyFatRate] float(24),
  [Bmi] float(24) NOT NULL
)
GO

CREATE TABLE [UserTrainingFrequency] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [Monday] bit NOT NULL,
  [Tuesday] bit NOT NULL,
  [Wednesday] bit NOT NULL,
  [Thursday] bit NOT NULL,
  [Friday] bit NOT NULL,
  [Saturday] bit NOT NULL,
  [Sunday] bit NOT NULL
)
GO

CREATE TABLE [Training] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserPreferencesId] int NOT NULL,
  [TrainingTypeCode] varchar(40) NOT NULL,
  [Duration] tinyint NOT NULL,
  [CreationDate] datetime NOT NULL,
  [CreatedBy] varchar(35) NOT NULL
)
GO

CREATE TABLE [TrainingDuration] (
  [Code] varchar(40) PRIMARY KEY NOT NULL
)
GO

CREATE TABLE [ExerciceTraining] (
  [Id] int PRIMARY KEY NOT NULL,
  [ExerciceId] smallint NOT NULL,
  [TrainingId] int NOT NULL,
  [NbSets] tinyint,
  [NbReps] tinyint,
  [EffortDuration] float NOT NULL,
  [RestDuration] float NOT NULL
)
GO

CREATE TABLE [Exercice] (
  [Id] smallint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] varchar(80) NOT NULL,
  [Description] varchar(600),
  [EquipmentCode] varchar(40) NOT NULL
)
GO

CREATE TABLE [ExerciceTrainingType] (
  [ExerciceId] smallint NOT NULL,
  [TrainingTypeCode] varchar(40) NOT NULL,
  PRIMARY KEY ([ExerciceId], [TrainingTypeCode])
)
GO

CREATE TABLE [TrainingType] (
  [Code] varchar(40) PRIMARY KEY NOT NULL
)
GO

CREATE TABLE [ExerciceGoal] (
  [ExerciceId] smallint NOT NULL,
  [GoalCode] varchar(40) NOT NULL,
  PRIMARY KEY ([ExerciceId], [GoalCode])
)
GO

CREATE TABLE [Goal] (
  [Code] varchar(40) PRIMARY KEY NOT NULL
)
GO

CREATE TABLE [ExerciceMuscleGroup] (
  [ExerciceId] smallint NOT NULL,
  [MuscleGroupCode] varchar(40) NOT NULL,
  PRIMARY KEY ([ExerciceId], [MuscleGroupCode])
)
GO

CREATE TABLE [MuscleGroup] (
  [Code] varchar(40) PRIMARY KEY NOT NULL
)
GO

CREATE TABLE [Equipment] (
  [Code] varchar(40) PRIMARY KEY NOT NULL
)
GO

ALTER TABLE [UserPhysicalInformation] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [UserPreferences] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [UserTrainingFrequency] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [UserPreferences] ADD FOREIGN KEY ([GoalCode]) REFERENCES [Goal] ([Code])
GO

ALTER TABLE [UserPreferences] ADD FOREIGN KEY ([TrainingTypeCode]) REFERENCES [TrainingType] ([Code])
GO

ALTER TABLE [UserPreferences] ADD FOREIGN KEY ([TrainingDurationCode]) REFERENCES [TrainingDuration] ([Code])
GO

ALTER TABLE [UserPreferences] ADD FOREIGN KEY ([EquipmentCode]) REFERENCES [Equipment] ([Code])
GO

ALTER TABLE [Training] ADD FOREIGN KEY ([UserPreferencesId]) REFERENCES [UserPreferences] ([Id])
GO

ALTER TABLE [Training] ADD FOREIGN KEY ([TrainingTypeCode]) REFERENCES [TrainingType] ([Code])
GO

ALTER TABLE [ExerciceTraining] ADD FOREIGN KEY ([ExerciceId]) REFERENCES [Exercice] ([Id])
GO

ALTER TABLE [ExerciceTraining] ADD FOREIGN KEY ([TrainingId]) REFERENCES [Training] ([Id])
GO

ALTER TABLE [Exercice] ADD FOREIGN KEY ([EquipmentCode]) REFERENCES [Equipment] ([Code])
GO

ALTER TABLE [ExerciceTrainingType] ADD FOREIGN KEY ([ExerciceId]) REFERENCES [Exercice] ([Id])
GO

ALTER TABLE [ExerciceTrainingType] ADD FOREIGN KEY ([TrainingTypeCode]) REFERENCES [TrainingType] ([Code])
GO

ALTER TABLE [ExerciceGoal] ADD FOREIGN KEY ([ExerciceId]) REFERENCES [Exercice] ([Id])
GO

ALTER TABLE [ExerciceGoal] ADD FOREIGN KEY ([GoalCode]) REFERENCES [Goal] ([Code])
GO

ALTER TABLE [ExerciceMuscleGroup] ADD FOREIGN KEY ([ExerciceId]) REFERENCES [Exercice] ([Id])
GO

ALTER TABLE [ExerciceMuscleGroup] ADD FOREIGN KEY ([MuscleGroupCode]) REFERENCES [MuscleGroup] ([Code])
GO

