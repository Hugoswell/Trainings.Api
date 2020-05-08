USE[Trainings]
GO

-- ExerciceTraining
CREATE INDEX FK__ExerciceTraining__ExerciceId ON dbo.ExerciceTraining (ExerciceId);
CREATE INDEX FK__ExerciceTraining__TrainingId ON dbo.ExerciceTraining (TrainingId);

-- Trainings
CREATE INDEX FK__Training__UserPreferencesId ON dbo.Training (UserPreferencesId);
CREATE INDEX FK__Training__TrainingTypeId ON dbo.Training (TrainingTypeId);

-- UserPhysicalInformation
CREATE INDEX FK__UserPhysicalInformation__UserId ON dbo.UserPhysicalInformation (UserId);
CREATE INDEX FK__UserPhysicalInformation__LevelId ON dbo.UserPhysicalInformation (LevelId);
CREATE INDEX FK__UserPhysicalInformation__SexId ON dbo.UserPhysicalInformation (SexId);

-- UserPreferences
CREATE INDEX FK__UserPreferences__UserId ON dbo.UserPreferences (UserId);
CREATE INDEX FK__UserPreferences__GoalId ON dbo.UserPreferences (GoalId);
CREATE INDEX FK__UserPreferences__TrainingTypeId ON dbo.UserPreferences (TrainingTypeId);
CREATE INDEX FK__UserPreferences__TrainingDurationId ON dbo.UserPreferences (TrainingDurationId);
CREATE INDEX FK__UserPreferences__EquipmentId ON dbo.UserPreferences (EquipmentId);

-- UserTrainingFrequency
CREATE INDEX FK__UserTrainingFrequency__UserId ON dbo.UserTrainingFrequency (UserId);