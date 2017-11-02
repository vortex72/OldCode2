using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace eClub.Models
{
    [Table("dSECModule")]
    public class AppScreen
    {
        [Key]
        public int SECScreen_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string SECScreen_Name { get; set; }
    }
    //public virtual ICollection<RoleScreen> RoleScreens { get; set; }
}
