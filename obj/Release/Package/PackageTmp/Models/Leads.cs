using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eClub.Models
{
    [Table("mReferred")]
    public class LeadsModel
    {
        [Key]
        public int mClient_ID { get; set; }
        public int mReferred_ID { get; set; }
        public string mReferred_FirstName { get; set; }
        public string mReferred_LastName { get; set; }
        public int mReferred_Phone1 { get; set; }
        public int mReferred_Phone2 { get; set; }
        public int mReferred_Phone3 { get; set; }
        public DateTime mReferred_BirthDate { get; set; }
        public string mReferred_Comments { get; set; }
    }
}
