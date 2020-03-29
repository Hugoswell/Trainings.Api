using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainings.Data.Tables
{
    public partial class LovCategory
    {
        public LovCategory()
        {
            Lov = new HashSet<Lov>();
        }

        [Key]
        [StringLength(35)]
        public string Code { get; set; }

        [InverseProperty("LovCategoryNavigation")]
        public virtual ICollection<Lov> Lov { get; set; }
    }
}
