using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class UserPreferences
    {
        public UserPreferences()
        {
            Training = new HashSet<Training>();
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte GoalId { get; set; }
        public byte TrainingTypeId { get; set; }
        public byte TrainingDurationId { get; set; }
        public byte EquipmentId { get; set; }

        [ForeignKey(nameof(EquipmentId))]
        [InverseProperty("UserPreferences")]
        public virtual Equipment Equipment { get; set; }
        [ForeignKey(nameof(GoalId))]
        [InverseProperty("UserPreferences")]
        public virtual Goal Goal { get; set; }
        [ForeignKey(nameof(TrainingDurationId))]
        [InverseProperty("UserPreferences")]
        public virtual TrainingDuration TrainingDuration { get; set; }
        [ForeignKey(nameof(TrainingTypeId))]
        [InverseProperty("UserPreferences")]
        public virtual TrainingType TrainingType { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserPreferences")]
        public virtual User User { get; set; }
        [InverseProperty("UserPreferences")]
        public virtual ICollection<Training> Training { get; set; }
    }
}
