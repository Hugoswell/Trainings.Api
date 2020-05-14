namespace Trainings.Repository
{
    using Trainings.Data.Context;
    using Trainings.Repository.Interfaces;

    public class TrainingRepository : BaseRepository, ITrainingRepository
    {
        public TrainingRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }
    }
}
