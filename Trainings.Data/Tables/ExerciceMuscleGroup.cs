﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class ExerciceMuscleGroup
    {
        [Key]
        public short ExerciceId { get; set; }
        [Key]
        [StringLength(40)]
        public string MuscleGroupCode { get; set; }

        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty("ExerciceMuscleGroup")]
        public virtual Exercice Exercice { get; set; }
        [ForeignKey(nameof(MuscleGroupCode))]
        [InverseProperty(nameof(MuscleGroup.ExerciceMuscleGroup))]
        public virtual MuscleGroup MuscleGroupCodeNavigation { get; set; }
    }
}