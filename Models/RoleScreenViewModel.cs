//using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace eClub.Models
{
    [Table("SECRoleModule")]
    public partial class RoleModuleViewModel
    {
        [Key]
        public int SECRole_ID { get; set; }
        public int dSECModule_ID { get; set; }

        [Column(TypeName = "bit")]
        public bool SECRoleModule_Modify { get; set; }

        [Column(TypeName = "bit")]
        public bool SECRoleModule_Delete { get; set; }

        [Column(TypeName = "bit")]
        public bool SECRoleModule_Print { get; set; }

        [Column(TypeName = "bit")]
        public bool SECRoleModule_Query { get; set; }

    }
}
