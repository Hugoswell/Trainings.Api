USE[Trainings]
GO

-- Goal
SET IDENTITY_INSERT Trainings.dbo.Goal ON
INSERT INTO dbo.Goal (Id, Name) VALUES (1, 'WeightLoss')
INSERT INTO dbo.Goal (Id, Name) VALUES (2, 'WeightGain')
INSERT INTO dbo.Goal (Id, Name) VALUES (3, 'Explosiveness')
INSERT INTO dbo.Goal (Id, Name) VALUES (4, 'Strength')
SET IDENTITY_INSERT Trainings.dbo.Goal OFF

-- TrainingType
SET IDENTITY_INSERT Trainings.dbo.TrainingType ON
INSERT INTO dbo.TrainingType (Id, Name) VALUES (1, 'BodyBuilding')
INSERT INTO dbo.TrainingType (Id, Name) VALUES (2, 'Cardio')
INSERT INTO dbo.TrainingType (Id, Name) VALUES (3, 'Crossfit')
INSERT INTO dbo.TrainingType (Id, Name) VALUES (4, 'HIIT')
SET IDENTITY_INSERT Trainings.dbo.TrainingType OFF

-- TrainingDuration
SET IDENTITY_INSERT Trainings.dbo.TrainingDuration ON
INSERT INTO dbo.TrainingDuration (Id, Name) VALUES (1, '15-20')
INSERT INTO dbo.TrainingDuration (Id, Name) VALUES (2, '20-30')
INSERT INTO dbo.TrainingDuration (Id, Name) VALUES (3, '30-45')
INSERT INTO dbo.TrainingDuration (Id, Name) VALUES (4, '45-90')
SET IDENTITY_INSERT Trainings.dbo.TrainingDuration OFF

-- Equipment
SET IDENTITY_INSERT Trainings.dbo.Equipment ON
INSERT INTO dbo.Equipment (Id, Name) VALUES (1, 'BodyWeight')
INSERT INTO dbo.Equipment (Id, Name) VALUES (2, 'Gym')
INSERT INTO dbo.Equipment (Id, Name) VALUES (3, 'HomeMaterial')
SET IDENTITY_INSERT Trainings.dbo.Equipment OFF

-- MuscleGroup
SET IDENTITY_INSERT Trainings.dbo.MuscleGroup ON
INSERT INTO dbo.MuscleGroup (Id, Name) VALUES (1, 'Legs')
INSERT INTO dbo.MuscleGroup (Id, Name) VALUES (2, 'Arms')
INSERT INTO dbo.MuscleGroup (Id, Name) VALUES (3, 'Shoulders')
INSERT INTO dbo.MuscleGroup (Id, Name) VALUES (4, 'Pectoral')
INSERT INTO dbo.MuscleGroup (Id, Name) VALUES (5, 'Back')
INSERT INTO dbo.MuscleGroup (Id, Name) VALUES (6, 'Abs')
INSERT INTO dbo.MuscleGroup (Id, Name) VALUES (7, 'Glutes')
SET IDENTITY_INSERT Trainings.dbo.MuscleGroup OFF

-- UserLevel
SET IDENTITY_INSERT Trainings.dbo.UserLevel ON
INSERT INTO dbo.UserLevel (Id, [Name]) VALUES (1, 'Beginner')
INSERT INTO dbo.UserLevel (Id, [Name]) VALUES (2, 'Confirmed')
INSERT INTO dbo.UserLevel (Id, [Name]) VALUES (3, 'Expert')
SET IDENTITY_INSERT Trainings.dbo.UserLevel OFF

-- UserSex
SET IDENTITY_INSERT Trainings.dbo.UserSex ON
INSERT INTO dbo.UserSex (Id, [Name]) VALUES (1, 'Man')
INSERT INTO dbo.UserSex (Id, [Name]) VALUES (2, 'Woman')
SET IDENTITY_INSERT Trainings.dbo.UserSex OFF

