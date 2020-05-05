USE[Trainings]
GO

CREATE TABLE [User] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [RoleCode] varchar(30) NOT NULL,
  [FirstName] varchar(40) NOT NULL,
  [LastName] varchar(40) NOT NULL,
  [Email] varchar(100) UNIQUE NOT NULL,
  [HashedPassword] varchar(100) NOT NULL,
  [HasFilledInformation] bit NOT NULL,
  [CreationDate] datetime NOT NULL,
  [FillInformationDate] datetime
)
GO

CREATE TABLE [UserPreferences] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [GoalId] tinyint NOT NULL,
  [TrainingTypeId] tinyint NOT NULL,
  [TrainingDurationId] tinyint NOT NULL,
  [EquipmentId] tinyint NOT NULL
)
GO

CREATE TABLE [UserPhysicalInformation] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [Level] tinyint NOT NULL,
  [Height] float(24) NOT NULL,
  [Weight] float(24) NOT NULL,
  [Age] tinyint NOT NULL,
  [Sex] tinyint NOT NULL,
  [BodyFatRate] float(24),
  [Bmi] float(24) NOT NULL
)
GO

CREATE TABLE [UserLevel] (
  [Id] tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] varchar(40) NOT NULL
)
GO

CREATE TABLE [UserSex] (
  [Id] tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] varchar(40) NOT NULL
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
  [TrainingTypeId] tinyint NOT NULL,
  [Duration] tinyint NOT NULL,
  [CreationDate] datetime NOT NULL,
  [CreatedBy] varchar(35) NOT NULL
)
GO

CREATE TABLE [TrainingDuration] (
  [Id] tinyint PRIMARY KEY NOT NULL,
  [Name] varchar(40) NOT NULL
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
  [EquipmentId] tinyint NOT NULL
)
GO

CREATE TABLE [ExerciceTrainingType] (
  [ExerciceId] smallint NOT NULL,
  [TrainingTypeId] tinyint NOT NULL,
  PRIMARY KEY ([ExerciceId], [TrainingTypeId])
)
GO

CREATE TABLE [TrainingType] (
  [Id] tinyint PRIMARY KEY NOT NULL,
  [Name] varchar(40) NOT NULL
)
GO

CREATE TABLE [ExerciceGoal] (
  [ExerciceId] smallint NOT NULL,
  [GoalId] tinyint NOT NULL,
  PRIMARY KEY ([ExerciceId], [GoalId])
)
GO

CREATE TABLE [Goal] (
  [Id] tinyint PRIMARY KEY NOT NULL,
  [Name] varchar(40) NOT NULL
)
GO

CREATE TABLE [ExerciceMuscleGroup] (
  [ExerciceId] smallint NOT NULL,
  [MuscleGroupId] tinyint NOT NULL,
  PRIMARY KEY ([ExerciceId], [MuscleGroupId])
)
GO

CREATE TABLE [MuscleGroup] (
  [Id] tinyint PRIMARY KEY NOT NULL,
  [Name] varchar(40) NOT NULL
)
GO

CREATE TABLE [Equipment] (
  [Id] tinyint PRIMARY KEY NOT NULL,
  [Name] varchar(40) NOT NULL
)
GO

ALTER TABLE [UserPhysicalInformation] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [UserPreferences] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [UserTrainingFrequency] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [UserPreferences] ADD FOREIGN KEY ([GoalId]) REFERENCES [Goal] ([Id])
GO

ALTER TABLE [UserPreferences] ADD FOREIGN KEY ([TrainingTypeId]) REFERENCES [TrainingType] ([Id])
GO

ALTER TABLE [UserPreferences] ADD FOREIGN KEY ([TrainingDurationId]) REFERENCES [TrainingDuration] ([Id])
GO

ALTER TABLE [UserPreferences] ADD FOREIGN KEY ([EquipmentId]) REFERENCES [Equipment] ([Id])
GO

ALTER TABLE [UserPhysicalInformation] ADD FOREIGN KEY ([Level]) REFERENCES [UserLevel] ([Id])
GO

ALTER TABLE [UserPhysicalInformation] ADD FOREIGN KEY ([Sex]) REFERENCES [UserSex] ([Id])
GO

ALTER TABLE [Training] ADD FOREIGN KEY ([UserPreferencesId]) REFERENCES [UserPreferences] ([Id])
GO

ALTER TABLE [Training] ADD FOREIGN KEY ([TrainingTypeId]) REFERENCES [TrainingType] ([Id])
GO

ALTER TABLE [ExerciceTraining] ADD FOREIGN KEY ([ExerciceId]) REFERENCES [Exercice] ([Id])
GO

ALTER TABLE [ExerciceTraining] ADD FOREIGN KEY ([TrainingId]) REFERENCES [Training] ([Id])
GO

ALTER TABLE [Exercice] ADD FOREIGN KEY ([EquipmentId]) REFERENCES [Equipment] ([Id])
GO

ALTER TABLE [ExerciceTrainingType] ADD FOREIGN KEY ([ExerciceId]) REFERENCES [Exercice] ([Id])
GO

ALTER TABLE [ExerciceTrainingType] ADD FOREIGN KEY ([TrainingTypeId]) REFERENCES [TrainingType] ([Id])
GO

ALTER TABLE [ExerciceGoal] ADD FOREIGN KEY ([ExerciceId]) REFERENCES [Exercice] ([Id])
GO

ALTER TABLE [ExerciceGoal] ADD FOREIGN KEY ([GoalId]) REFERENCES [Goal] ([Id])
GO

ALTER TABLE [ExerciceMuscleGroup] ADD FOREIGN KEY ([ExerciceId]) REFERENCES [Exercice] ([Id])
GO

ALTER TABLE [ExerciceMuscleGroup] ADD FOREIGN KEY ([MuscleGroupId]) REFERENCES [MuscleGroup] ([Id])
GO