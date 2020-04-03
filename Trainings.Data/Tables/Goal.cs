using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class Goal
    {
        public Goal()
        {
            ExerciceGoal = new HashSet<ExerciceGoal>();
            UserPreferences = new HashSet<UserPreferences>();
        }

        [Key]
        [StringLength(40)]
        public string Code { get; set; }

        [InverseProperty("GoalCodeNavigation")]
        public virtual ICollection<ExerciceGoal> ExerciceGoal { get; set; }
        [InverseProperty("GoalCodeNavigation")]
        public virtual ICollection<UserPreferences> UserPreferences { get; set; }
    }
}
