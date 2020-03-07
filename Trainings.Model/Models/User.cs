using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Models
{
    public partial class User
    {
        public User()
        {
            PersonalInformation = new HashSet<PersonalInformation>();
            UserPreference = new HashSet<UserPreference>();
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

        [InverseProperty("User")]
        public virtual ICollection<PersonalInformation> PersonalInformation { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserPreference> UserPreference { get; set; }
    }
}
