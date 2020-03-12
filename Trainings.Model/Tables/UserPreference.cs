using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class UserPreference
    {
        public UserPreference()
        {
            Training = new HashSet<Training>();
            TrainingFrequency = new HashSet<TrainingFrequency>();
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public short TrainingTypeId { get; set; }
        public byte? TrainingDuration { get; set; }
        public bool? BodyWeightWorkout { get; set; }

        [ForeignKey(nameof(TrainingTypeId))]
        [InverseProperty(nameof(Lov.UserPreference))]
        public virtual Lov TrainingType { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserPreference")]
        public virtual User User { get; set; }
        [InverseProperty("UserPreference")]
        public virtual ICollection<Training> Training { get; set; }
        [InverseProperty("UserPreference")]
        public virtual ICollection<TrainingFrequency> TrainingFrequency { get; set; }
    }
}
