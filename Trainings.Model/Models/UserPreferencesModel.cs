namespace Trainings.Model.Models
{
    public class UserPreferencesModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public byte EquipmentId { get; set; }

        public byte GoalId { get; set; }

        public byte TrainingDurationId { get; set; }

        public byte TrainingTypeId { get; set; }
    }
}
