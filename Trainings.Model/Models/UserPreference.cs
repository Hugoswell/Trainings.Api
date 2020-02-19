using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Models
{
    public partial class UserPreference
    {
        public UserPreference()
        {
            Trainings = new HashSet<Training>();
            TrainingFrequencies = new HashSet<TrainingFrequency>();
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public short? TrainingTypeId { get; set; }
        public byte? TrainingDuration { get; set; }
        public bool? BodyWeightWorkout { get; set; }

        [ForeignKey(nameof(TrainingTypeId))]
        [InverseProperty(nameof(Lov.UserPreferences))]
        public virtual Lov TrainingType { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserPreference")]
        public virtual User User { get; set; }

        [InverseProperty("UserPreference")]
        public virtual ICollection<Training> Trainings { get; set; }

        [InverseProperty("UserPreference")]
        public virtual ICollection<TrainingFrequency> TrainingFrequencies { get; set; }
    }
}
