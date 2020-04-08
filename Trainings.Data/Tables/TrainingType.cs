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
        public byte Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [InverseProperty("TrainingType")]
        public virtual ICollection<ExerciceTrainingType> ExerciceTrainingType { get; set; }
        [InverseProperty("TrainingType")]
        public virtual ICollection<Training> Training { get; set; }
        [InverseProperty("TrainingType")]
        public virtual ICollection<UserPreferences> UserPreferences { get; set; }
    }
}
