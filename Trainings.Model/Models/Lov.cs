using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Models
{
    public partial class Lov
    {
        public Lov()
        {
            Exercices = new HashSet<Exercice>();
            UserPreferences = new HashSet<UserPreference>();
        }

        [Key]
        public short Id { get; set; }

        public short IdLovType { get; set; }

        [Required]
        [StringLength(30)]
        public string LovTypeName { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }


        [InverseProperty("ExerciceNavigation")]
        public virtual ICollection<Exercice> Exercices { get; set; }

        [InverseProperty("TrainingType")]
        public virtual ICollection<UserPreference> UserPreferences { get; set; }
    }
}
