using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class Equipment
    {
        public Equipment()
        {
            ExerciceEquipment = new HashSet<ExerciceEquipment>();
            UserPreferences = new HashSet<UserPreferences>();
        }

        [Key]
        public byte Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [InverseProperty("Equipment")]
        public virtual ICollection<ExerciceEquipment> ExerciceEquipment { get; set; }
        [InverseProperty("Equipment")]
        public virtual ICollection<UserPreferences> UserPreferences { get; set; }
    }
}
