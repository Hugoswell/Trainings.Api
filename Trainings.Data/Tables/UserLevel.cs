using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class UserLevel
    {
        public UserLevel()
        {
            UserPhysicalInformation = new HashSet<UserPhysicalInformation>();
        }

        [Key]
        public byte Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [InverseProperty("Level")]
        public virtual ICollection<UserPhysicalInformation> UserPhysicalInformation { get; set; }
    }
}
