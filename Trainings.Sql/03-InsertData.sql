USE[Trainings]
GO

-- Goal
INSERT INTO dbo.Goal VALUES (1, 'WeightLoss')
INSERT INTO dbo.Goal VALUES (2, 'WeightGain')
INSERT INTO dbo.Goal VALUES (3, 'Explosiveness')
INSERT INTO dbo.Goal VALUES (4, 'Strength')

-- TrainingType
INSERT INTO dbo.TrainingType VALUES (1, 'BodyBuilding')
INSERT INTO dbo.TrainingType VALUES (2, 'Cardio')
INSERT INTO dbo.TrainingType VALUES (3, 'Crossfit')
INSERT INTO dbo.TrainingType VALUES (4, 'HIIT')

-- TrainingDuration
INSERT INTO dbo.TrainingDuration VALUES (1, '15-30')
INSERT INTO dbo.TrainingDuration VALUES (2, '30-45')
INSERT INTO dbo.TrainingDuration VALUES (3, '45-1')
INSERT INTO dbo.TrainingDuration VALUES (4, '1-2')

-- Equipment
INSERT INTO dbo.Equipment VALUES (1, 'BodyWeight')
INSERT INTO dbo.Equipment VALUES (2, 'Gym')
INSERT INTO dbo.Equipment VALUES (3, 'HomeMaterial')

-- MuscleGroup
INSERT INTO dbo.MuscleGroup VALUES (1, 'Legs')
INSERT INTO dbo.MuscleGroup VALUES (2, 'Arms')
INSERT INTO dbo.MuscleGroup VALUES (3, 'Shoulders')
INSERT INTO dbo.MuscleGroup VALUES (4, 'Pectoral')
INSERT INTO dbo.MuscleGroup VALUES (5, 'Back')
INSERT INTO dbo.MuscleGroup VALUES (6, 'Abs')
INSERT INTO dbo.MuscleGroup VALUES (7, 'Glutes')

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

