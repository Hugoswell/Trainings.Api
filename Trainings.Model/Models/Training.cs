using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Models
{
    public partial class Training
    {
        public Training()
        {
            Exercices = new HashSet<Exercice>();
        }

        [Key]
        public int Id { get; set; }
        public int UserPreferenceId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        public byte NbOfExercice { get; set; }
        public byte Duration { get; set; }

        [ForeignKey(nameof(UserPreferenceId))]
        [InverseProperty("Training")]
        public virtual UserPreference UserPreference { get; set; }
        [InverseProperty("Training")]
        public virtual ICollection<Exercice> Exercices { get; set; }
    }
}
