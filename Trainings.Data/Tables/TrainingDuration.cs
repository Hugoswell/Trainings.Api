using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class TrainingDuration
    {
        public TrainingDuration()
        {
            UserPreferences = new HashSet<UserPreferences>();
        }

        [Key]
        [StringLength(40)]
        public string Code { get; set; }

        [InverseProperty("TrainingDurationCodeNavigation")]
        public virtual ICollection<UserPreferences> UserPreferences { get; set; }
    }
}
