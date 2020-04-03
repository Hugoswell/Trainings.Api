﻿using System;
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
        [StringLength(40)]
        public string Code { get; set; }

        [InverseProperty("MuscleGroupCodeNavigation")]
        public virtual ICollection<ExerciceMuscleGroup> ExerciceMuscleGroup { get; set; }
    }
}