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
            ExerciceMuscleGroup = new HashSet<ExerciceMuscleGroup>();
        }

        [Key]
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public short TrainingTypeId { get; set; }
        public short ExerciceId { get; set; }
        public byte? NbOfSets { get; set; }
        public byte? NbOfRepetitions { get; set; }
        public double? Duration { get; set; }
        public double RestDuration { get; set; }
        public bool IsBodyWeight { get; set; }

        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty(nameof(Lov.ExerciceExerciceNavigation))]
        public virtual Lov ExerciceNavigation { get; set; }
        [ForeignKey(nameof(TrainingId))]
        [InverseProperty("Exercice")]
        public virtual Training Training { get; set; }
        [ForeignKey(nameof(TrainingTypeId))]
        [InverseProperty(nameof(Lov.ExerciceTrainingType))]
        public virtual Lov TrainingType { get; set; }
        [InverseProperty("Exercice")]
        public virtual ICollection<ExerciceMuscleGroup> ExerciceMuscleGroup { get; set; }
    }
}
