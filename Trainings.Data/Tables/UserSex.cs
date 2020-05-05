using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class UserSex
    {
        public UserSex()
        {
            UserPhysicalInformation = new HashSet<UserPhysicalInformation>();
        }

        [Key]
        public byte Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [InverseProperty("SexNavigation")]
        public virtual ICollection<UserPhysicalInformation> UserPhysicalInformation { get; set; }
    }
}
