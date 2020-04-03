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
        [Required]
        [StringLength(40)]
        public string GoalCode { get; set; }
        [Required]
        [StringLength(40)]
        public string TrainingTypeCode { get; set; }
        [Required]
        [StringLength(40)]
        public string TrainingDurationCode { get; set; }
        [Required]
        [StringLength(40)]
        public string EquipmentCode { get; set; }

        [ForeignKey(nameof(EquipmentCode))]
        [InverseProperty(nameof(Equipment.UserPreferences))]
        public virtual Equipment EquipmentCodeNavigation { get; set; }
        [ForeignKey(nameof(GoalCode))]
        [InverseProperty(nameof(Goal.UserPreferences))]
        public virtual Goal GoalCodeNavigation { get; set; }
        [ForeignKey(nameof(TrainingDurationCode))]
        [InverseProperty(nameof(TrainingDuration.UserPreferences))]
        public virtual TrainingDuration TrainingDurationCodeNavigation { get; set; }
        [ForeignKey(nameof(TrainingTypeCode))]
        [InverseProperty(nameof(TrainingType.UserPreferences))]
        public virtual TrainingType TrainingTypeCodeNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserPreferences")]
        public virtual User User { get; set; }
        [InverseProperty("UserPreferences")]
        public virtual ICollection<Training> Training { get; set; }
    }
}
