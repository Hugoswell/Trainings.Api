namespace Trainings.Repository
{
    using System;
    using Trainings.Data.Context;
    using Trainings.Model.Models;
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
                return 1;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
