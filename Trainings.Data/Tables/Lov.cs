using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class Lov
    {
        public Lov()
        {
            ExerciceExerciceNavigation = new HashSet<Exercice>();
            ExerciceTrainingType = new HashSet<Exercice>();
            UserPreference = new HashSet<UserPreference>();
        }

        [Key]
        public short Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        [Required]
        [StringLength(35)]
        public string LovCategory { get; set; }

        [ForeignKey(nameof(LovCategory))]
        [InverseProperty("Lov")]
        public virtual LovCategory LovCategoryNavigation { get; set; }
        [InverseProperty(nameof(Exercice.ExerciceNavigation))]
        public virtual ICollection<Exercice> ExerciceExerciceNavigation { get; set; }
        [InverseProperty(nameof(Exercice.TrainingType))]
        public virtual ICollection<Exercice> ExerciceTrainingType { get; set; }
        [InverseProperty("TrainingType")]
        public virtual ICollection<UserPreference> UserPreference { get; set; }
    }
}
