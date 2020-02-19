using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Models
{
    public partial class PersonalInformation
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public byte? Age { get; set; }
        public bool? Sex { get; set; }
        public float? BodyFatRate { get; set; }
        [StringLength(30)]
        public string ProfileLevel { get; set; }
        public float? Bmi { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("PersonalInformation")]
        public virtual User User { get; set; }
    }
}
