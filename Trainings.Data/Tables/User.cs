using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class User
    {
        public User()
        {
            UserPhysicalInformation = new HashSet<UserPhysicalInformation>();
            UserPreferences = new HashSet<UserPreferences>();
            UserTrainingFrequency = new HashSet<UserTrainingFrequency>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string RoleCode { get; set; }
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
        public string HashedPassword { get; set; }
        public bool HasFillInformation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FillInformationDate { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserPhysicalInformation> UserPhysicalInformation { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserPreferences> UserPreferences { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserTrainingFrequency> UserTrainingFrequency { get; set; }
    }
}
