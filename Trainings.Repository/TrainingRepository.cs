namespace Trainings.Repository
{
    using System;
    using System.Linq;
    using Trainings.Data.Context;
    using Trainings.Data.Tables;
    using Trainings.Model.Models;
    using Trainings.Repository.Assemblers;
    using Trainings.Repository.Interfaces;

    public class TrainingRepository : BaseRepository, ITrainingRepository
    {
        public TrainingRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public int? Create(TrainingModel trainingModel)
        {
            try
            {
                
                Training training = trainingModel.ToTraining();
                _trainingsEntities.Training.Add(training);
                _trainingsEntities.SaveChanges();

                foreach (ExerciceTrainingModel exerciceTrainingModel in trainingModel.ExerciceTrainingModels)
                {
                    ExerciceTraining exerciceTraining = exerciceTrainingModel.ToExerciceTraining(training.Id);
                    _trainingsEntities.ExerciceTraining.Add(exerciceTraining);
                }

                _trainingsEntities.SaveChanges();
                return training.Id;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
