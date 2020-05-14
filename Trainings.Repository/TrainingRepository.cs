namespace Trainings.Repository
{
    using System;
    using Trainings.Data.Context;
    using Trainings.Repository.Interfaces;

    public class TrainingRepository : BaseRepository, ITrainingRepository
    {
        public TrainingRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public int? Create()
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
