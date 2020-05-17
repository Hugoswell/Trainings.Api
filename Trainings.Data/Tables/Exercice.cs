using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class Exercice
    {
        public Exercice()
        {
            ExerciceEquipment = new HashSet<ExerciceEquipment>();
            ExerciceGoal = new HashSet<ExerciceGoal>();
            ExerciceMuscleGroup = new HashSet<ExerciceMuscleGroup>();
            ExerciceTraining = new HashSet<ExerciceTraining>();
            ExerciceTrainingType = new HashSet<ExerciceTrainingType>();
        }

        [Key]
        public short Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [StringLength(600)]
        public string Description { get; set; }

        [InverseProperty("Exercice")]
        public virtual ICollection<ExerciceEquipment> ExerciceEquipment { get; set; }
        [InverseProperty("Exercice")]
        public virtual ICollection<ExerciceGoal> ExerciceGoal { get; set; }
        [InverseProperty("Exercice")]
        public virtual ICollection<ExerciceMuscleGroup> ExerciceMuscleGroup { get; set; }
        [InverseProperty("Exercice")]
        public virtual ICollection<ExerciceTraining> ExerciceTraining { get; set; }
        [InverseProperty("Exercice")]
        public virtual ICollection<ExerciceTrainingType> ExerciceTrainingType { get; set; }
    }
}
