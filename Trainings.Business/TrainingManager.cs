namespace Trainings.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Trainings.Business.Interfaces;
    using Trainings.Model.Models;
    using Trainings.Repository.Interfaces;

    public class TrainingManager : ITrainingManager
    {
        #region Properties & Constructor

        private readonly ITrainingRepository _trainingRepository;
        private readonly IUserPreferencesRepository _userPreferencesRepository;
        private readonly IExerciceRepository _exerciceRepository;
        private const int REPETITION_DURATION = 4;

        public TrainingManager(
                ITrainingRepository trainingRepository,
                IUserPreferencesRepository userPreferencesRepository,
                IExerciceRepository exerciceRepository)
        {

            _trainingRepository = trainingRepository;
            _userPreferencesRepository = userPreferencesRepository;
            _exerciceRepository = exerciceRepository;
        }

        #endregion

        public IEnumerable<TrainingInfoModel> GetTrainingsInfo(int userId)
        {
            return _trainingRepository.GetTrainingsInfo(userId);
        }

        public int? Create(int userId)
        {
            IEnumerable<int> exercicesId = _exerciceRepository.GetFilteredExercicesId(userId);
            UserPreferencesModel userPreferences = _userPreferencesRepository.Get(userId);
            TrainingModel trainingModel = BuildTraining(exercicesId, userPreferences);
            return _trainingRepository.Create(trainingModel);
        }

        #region Private

        private TrainingModel BuildTraining(IEnumerable<int> exercicesId, UserPreferencesModel userPreferences)
        {
            return userPreferences.TrainingTypeId switch
            {
                1 => BuildMusculationTraining(exercicesId, userPreferences),
                2 => BuildCardioTraining(exercicesId, userPreferences),
                3 => BuildCrossfitOrHiitTraining(exercicesId, userPreferences),
                4 => BuildCrossfitOrHiitTraining(exercicesId, userPreferences),
                _ => null,
            };
        }

        private TrainingModel BuildMusculationTraining(IEnumerable<int> exercicesId, UserPreferencesModel userPreferences)
        {            
            List<ExerciceTrainingModel> exerciceTrainingModels = new List<ExerciceTrainingModel>();
            double trainingDuration = GetTrainingDuration(userPreferences.TrainingDurationId);
            double actualDuration = 0;

            while (actualDuration < trainingDuration)
            {
                ExerciceTrainingModel exerciceTrainingModel = BuildMusculationExerciceTraining(exercicesId);
                exerciceTrainingModels.Add(exerciceTrainingModel);
                actualDuration += (exerciceTrainingModel.EffortDuration + exerciceTrainingModel.RestDuration);
            }

            return new TrainingModel
            {
                CreatedBy = "Manually",
                CreationDate = DateTime.Now,
                TrainingTypeId = userPreferences.TrainingTypeId,
                UserPreferencesId = userPreferences.Id,
                NbTimes = null,
                Duration = (byte) actualDuration,
                ExerciceTrainingModels = exerciceTrainingModels
            };
        }

        private TrainingModel BuildCrossfitOrHiitTraining(IEnumerable<int> exercicesId, UserPreferencesModel userPreferences)
        {
            byte nbExercice = RandomizeByte(4, 8);
            byte? nbTimes = GetNbTimes(userPreferences.TrainingDurationId, nbExercice);

            List<ExerciceTrainingModel> exerciceTrainingModels = new List<ExerciceTrainingModel>();
            for (int i = 0; i < nbExercice; i++)
            {
                ExerciceTrainingModel exerciceTrainingModel = BuildCrossfitOrHiitExerciceTraining(exercicesId);
                exerciceTrainingModels.Add(exerciceTrainingModel);
            }

            return new TrainingModel
            {
                CreatedBy = "Manually",
                CreationDate = DateTime.Now,
                TrainingTypeId = userPreferences.TrainingTypeId,
                UserPreferencesId = userPreferences.Id,
                NbTimes = nbTimes,
                Duration = (byte) (nbTimes.Value * nbExercice),
                ExerciceTrainingModels = exerciceTrainingModels
            };
        }

        private TrainingModel BuildCardioTraining(IEnumerable<int> exercicesId, UserPreferencesModel userPreferences)
        {
            List<ExerciceTrainingModel> exerciceTrainingModels = new List<ExerciceTrainingModel>();
            ExerciceTrainingModel exerciceTrainingModel = BuildCardioExerciceTraining(exercicesId, userPreferences.TrainingDurationId);
            exerciceTrainingModels.Add(exerciceTrainingModel);

            return new TrainingModel
            {
                CreatedBy = "Manually",
                CreationDate = DateTime.Now,
                TrainingTypeId = userPreferences.TrainingTypeId,
                UserPreferencesId = userPreferences.Id,
                NbTimes = null,
                Duration = (byte) exerciceTrainingModel.EffortDuration,
                ExerciceTrainingModels = exerciceTrainingModels
            };
        }

        private ExerciceTrainingModel BuildMusculationExerciceTraining(IEnumerable<int> exercicesId)
        {
            byte NbSets = RandomizeByte(3, 5);
            byte NbReps = RandomizeNumberOfReps();
            return new ExerciceTrainingModel
            {
                ExerciceId = RandomizeExercice(exercicesId),
                EffortDuration = NbSets * NbReps * ((double)REPETITION_DURATION/60),
                RestDuration = 1.5 * NbSets,
                NbSets = NbSets,
                NbReps = NbReps
            };
        }

        private ExerciceTrainingModel BuildCrossfitOrHiitExerciceTraining(IEnumerable<int> exercicesId)
        {
            double effortDuration = RandomizeEffortDuration();
            return new ExerciceTrainingModel
            {
                ExerciceId = RandomizeExercice(exercicesId),
                EffortDuration = effortDuration,
                RestDuration = 1 - effortDuration,
                NbSets = null,
                NbReps = null
            };
        }

        private ExerciceTrainingModel BuildCardioExerciceTraining(IEnumerable<int> exercicesId, byte trainingDurationId)
        {
            return new ExerciceTrainingModel
            {
                ExerciceId = RandomizeExercice(exercicesId),
                EffortDuration = GetTrainingDuration(trainingDurationId),
                RestDuration = 5,
                NbSets = null,
                NbReps = null
            };
        }

        private byte? GetNbTimes(byte trainingDurationId, byte nbExercice)
        {
            return ComputeTrainingNbTimes(trainingDurationId, nbExercice);            
        }

        private byte ComputeTrainingNbTimes(byte trainingDurationId, byte nbExercice)
        {
            double trainingDuration = GetTrainingDuration(trainingDurationId);
            return (byte) Math.Ceiling(trainingDuration / nbExercice);
        }

        private double GetTrainingDuration(byte trainingDurationId)
        {
            double res = 0;
            switch (trainingDurationId)
            {
                case 1:
                    res = 15;
                    return res;
                case 2:
                    res = 25;
                    return res;
                case 3:
                    res = 40;
                    return res;
                case 4:
                    res = 70;
                    return res;
                default:                    
                    return res;
            }
        }

        private double RandomizeEffortDuration()
        {
            Random rand = new Random();
            double[] effortDuration = new double[] { (double)1/3, (double)5/12, (double)1/2, (double)7/12 };
            int randomIndex = rand.Next(effortDuration.Length);            
            return effortDuration[randomIndex];
        }

        private short RandomizeExercice(IEnumerable<int> exercicesId)
        {
            Random rand = new Random();
            int randomIndex = rand.Next(exercicesId.ToList().Count);
            return (short) exercicesId.ToList()[randomIndex];
        }

        private byte RandomizeByte(int lowBound, int highBound)
        {
            Random rand = new Random();
            return (byte) rand.Next(lowBound, highBound + 1);
        }

        private byte RandomizeNumberOfReps()
        {
            Random rand = new Random();
            byte[] nbReps = new byte[] { 8, 10, 12, 15 };
            int randomIndex = rand.Next(nbReps.Length);
            return (byte) nbReps[randomIndex];
        }

        #endregion
    }
}
