using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class UserTrainingFrequency
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserTrainingFrequency")]
        public virtual User User { get; set; }
    }
}
