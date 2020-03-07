using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Models
{
    public partial class TrainingFrequency
    {
        [Key]
        public int Id { get; set; }
        public int UserPreferenceId { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public bool? Sunday { get; set; }

        [ForeignKey(nameof(UserPreferenceId))]
        [InverseProperty("TrainingFrequency")]
        public virtual UserPreference UserPreference { get; set; }
    }
}
