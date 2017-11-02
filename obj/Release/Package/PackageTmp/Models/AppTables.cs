using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eClub.Models
{
    [Table("MASTERTABLE")]
    public class AppTables
    {
        [Key]
        public int MasterTable_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string MasterTable_Name { get; set; }

        [Required]
        [StringLength(450)]
        public string MasterTable_Description { get; set; }
    }
}
