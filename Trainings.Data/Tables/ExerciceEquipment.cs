using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class ExerciceEquipment
    {
        [Key]
        public short ExerciceId { get; set; }
        [Key]
        public byte EquipmentId { get; set; }

        [ForeignKey(nameof(EquipmentId))]
        [InverseProperty("ExerciceEquipment")]
        public virtual Equipment Equipment { get; set; }
        [ForeignKey(nameof(ExerciceId))]
        [InverseProperty("ExerciceEquipment")]
        public virtual Exercice Exercice { get; set; }
    }
}
