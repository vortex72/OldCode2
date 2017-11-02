using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eClub.Models
{
    [Table("SECRoleScreen")]
    public partial class RoleScreenViewModel
    {
        [Key]
        public int SECRole_ID { get; set; }
        public int SECScreen_ID { get; set; }

        [Column(TypeName = "bit")]
        public bool SECRoleScreen_Modify { get; set; }

        [Column(TypeName = "bit")]
        public bool SECRoleScreen_Delete { get; set; }

        [Column(TypeName = "bit")]
        public bool SECRoleScreen_Print { get; set; }

        [Column(TypeName = "bit")]
        public bool SECRoleScreen_Query { get; set; }

    }
}
