using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Model.Models
{
    public partial class User
    {
        public User()
        {
            PersonalInformations = new HashSet<PersonalInformation>();
            UserPreferences = new HashSet<UserPreference>();
        }

        [Key]
        public int Id { get; set; }

        public byte RoleId { get; set; }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string RoleName { get; set; }

        [InverseProperty("UserPersonalInformation")]
        public virtual ICollection<PersonalInformation> PersonalInformations { get; set; }

        [InverseProperty("UserUserPreference")]
        public virtual ICollection<UserPreference> UserPreferences { get; set; }
    }
}
