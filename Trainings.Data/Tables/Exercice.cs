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
        [Required]
        [StringLength(40)]
        public string EquipmentCode { get; set; }

        [ForeignKey(nameof(EquipmentCode))]
        [InverseProperty(nameof(Equipment.Exercice))]
        public virtual Equipment EquipmentCodeNavigation { get; set; }
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
