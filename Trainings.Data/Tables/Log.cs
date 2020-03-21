﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class Log
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(30)]
        public string Level { get; set; }
        [Required]
        [StringLength(30)]
        public string Type { get; set; }
        [Required]
        [StringLength(30)]
        public string Action { get; set; }
    }
}
