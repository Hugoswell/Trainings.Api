using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class Training
    {
        public Training()
        {
            ExerciceTraining = new HashSet<ExerciceTraining>();
        }

        [Key]
        public int Id { get; set; }
        public int UserPreferencesId { get; set; }
        [Required]
        [StringLength(40)]
        public string TrainingTypeCode { get; set; }
        public byte Duration { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Required]
        [StringLength(35)]
        public string CreatedBy { get; set; }

        [ForeignKey(nameof(TrainingTypeCode))]
        [InverseProperty(nameof(TrainingType.Training))]
        public virtual TrainingType TrainingTypeCodeNavigation { get; set; }
        [ForeignKey(nameof(UserPreferencesId))]
        [InverseProperty("Training")]
        public virtual UserPreferences UserPreferences { get; set; }
        [InverseProperty("Training")]
        public virtual ICollection<ExerciceTraining> ExerciceTraining { get; set; }
    }
}
