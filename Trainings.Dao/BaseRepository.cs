namespace Trainings.Repository
{
    using System;
    using Trainings.Data.Models;

    public class BaseRepository
    {
        protected readonly TrainingsEntities _trainingsEntities;

        public BaseRepository(TrainingsEntities trainingsEntities)
        {
            _trainingsEntities = trainingsEntities ?? throw new ArgumentNullException(nameof(trainingsEntities));
        }
    }
}
