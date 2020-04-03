using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class TrainingType
    {
        public TrainingType()
        {
            ExerciceTrainingType = new HashSet<ExerciceTrainingType>();
            Training = new HashSet<Training>();
            UserPreferences = new HashSet<UserPreferences>();
        }

        [Key]
        [StringLength(40)]
        public string Code { get; set; }

        [InverseProperty("TrainingTypeCodeNavigation")]
        public virtual ICollection<ExerciceTrainingType> ExerciceTrainingType { get; set; }
        [InverseProperty("TrainingTypeCodeNavigation")]
        public virtual ICollection<Training> Training { get; set; }
        [InverseProperty("TrainingTypeCodeNavigation")]
        public virtual ICollection<UserPreferences> UserPreferences { get; set; }
    }
}
