using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eClub.Models
{
    [Table("DescriptionTables")]
    public class DescriptionTables
    {
        [Key]
        public int DescTableID { get; set; }

        [Required]
        [StringLength(250)]
        public string DescTableSpanish { get; set; }

        [Required]
        [StringLength(250)]
        public string DescTableEnglish { get; set; }
    }
}
