namespace Trainings.Repository.Assemblers
{
    using Trainings.Data.Tables;
    using Trainings.Model.Models;

    internal static class UserPreferencesAssembler
    {
        internal static UserPreferencesModel ToUserPreferencesModel(this UserPreferences userPreferences)
        {
            return new UserPreferencesModel
            {
                Id = userPreferences.Id,
                UserId = userPreferences.UserId,
                EquipmentId = userPreferences.EquipmentId,
                GoalId = userPreferences.GoalId,
                TrainingDurationId = userPreferences.TrainingDurationId,
                TrainingTypeId = userPreferences.TrainingTypeId
            };
        }
    }
}
