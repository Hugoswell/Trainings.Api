using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class MuscleGroup
    {
        public MuscleGroup()
        {
            ExerciceMuscleGroup = new HashSet<ExerciceMuscleGroup>();
        }

        [Key]
        public byte Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [InverseProperty("MuscleGroup")]
        public virtual ICollection<ExerciceMuscleGroup> ExerciceMuscleGroup { get; set; }
    }
}
