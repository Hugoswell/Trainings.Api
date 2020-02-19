using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Models
{
    public partial class Exercice
    {
        [Key]
        public int Id { get; set; }

        public int TrainingId { get; set; }

        public short ExerciceId { get; set; }

        public byte? NbOfSets { get; set; }

        public byte? NbOfRepetitions { get; set; }

        public double? Duration { get; set; }

        public double RestDuration { get; set; }

        [Required]
        [StringLength(30)]
        public string MuscleGroup { get; set; }

        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty("ExerciceLov")]
        public virtual Lov Lov { get; set; }

        [ForeignKey(nameof(TrainingId))]
        [InverseProperty("ExerciceTraining")]
        public virtual Training Training { get; set; }
    }
}
