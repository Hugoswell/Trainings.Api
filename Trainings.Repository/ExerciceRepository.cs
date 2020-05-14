namespace Trainings.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Trainings.Data.Context;
    using Trainings.Repository.Assemblers;
    using Trainings.Repository.Interfaces;

    public class ExerciceRepository : BaseRepository, IExerciceRepository
    {
        public ExerciceRepository(TrainingsEntities trainingsEntities) : base(trainingsEntities)
        {
        }

        public IEnumerable<int> GetFilteredExercicesId(int userId)
        {
            return (
                from e in _trainingsEntities.Exercice

                //Training type filter
                join ett in _trainingsEntities.ExerciceTrainingType on e.Id equals ett.ExerciceId
                join tt in _trainingsEntities.TrainingType on ett.TrainingTypeId equals tt.Id
                join up in _trainingsEntities.UserPreferences on tt.Id equals up.TrainingTypeId

                //Goal filter
                join eg in _trainingsEntities.ExerciceGoal on e.Id equals eg.ExerciceId
                join g in _trainingsEntities.Goal on eg.GoalId equals g.Id
                join up2 in _trainingsEntities.UserPreferences on g.Id equals up2.GoalId

                //Equipment filter
                join ee in _trainingsEntities.ExerciceEquipment on e.Id equals ee.ExerciceId
                join eq in _trainingsEntities.Equipment on ee.EquipmentId equals eq.Id
                join up3 in _trainingsEntities.UserPreferences on eq.Id equals up3.EquipmentId

                where up.UserId.Equals(userId)
                select e.Id.ToInt()
            );
        }
    }
}
