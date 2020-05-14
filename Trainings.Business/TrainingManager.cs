namespace Trainings.Business
{
    using Trainings.Business.Interfaces;
    using Trainings.Repository.Interfaces;

    public class TrainingManager : ITrainingManager
    {
        #region Properties & Constructor

        private readonly ITrainingRepository _trainingRepository;

        public TrainingManager(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        #endregion
    }
}
