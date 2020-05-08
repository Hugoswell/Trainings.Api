using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class UserPhysicalInformation
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte LevelId { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public byte Age { get; set; }
        public byte SexId { get; set; }
        public float? BodyFatRate { get; set; }
        public float Bmi { get; set; }

        [ForeignKey(nameof(LevelId))]
        [InverseProperty(nameof(UserLevel.UserPhysicalInformation))]
        public virtual UserLevel Level { get; set; }
        [ForeignKey(nameof(SexId))]
        [InverseProperty(nameof(UserSex.UserPhysicalInformation))]
        public virtual UserSex Sex { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserPhysicalInformation")]
        public virtual User User { get; set; }
    }
}
