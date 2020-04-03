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
            Exercice = new HashSet<Exercice>();
            UserPreferences = new HashSet<UserPreferences>();
        }

        [Key]
        [StringLength(40)]
        public string Code { get; set; }

        [InverseProperty("EquipmentCodeNavigation")]
        public virtual ICollection<Exercice> Exercice { get; set; }
        [InverseProperty("EquipmentCodeNavigation")]
        public virtual ICollection<UserPreferences> UserPreferences { get; set; }
    }
}
