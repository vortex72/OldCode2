using System;
using System.Collections.Generic;
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

        [Required]
        public string mReferred_FirstName { get; set; }

        [Required]
        public string mReferred_LastName { get; set; }

        [Required]
        public string mReferred_Phone1 { get; set; }

        public string mReferred_Phone2 { get; set; }

        [EmailAddress]
        public string mReferred_eMail { get; set; }

        public DateTime mReferred_BirthDate { get; set; }

        public string mReferred_Comments { get; set; }

        public int dGender_ID { get; set; }

        public int dMaritalStatus_ID { get; set; }

        public IEnumerable<DescriptionTables> dGender { get; set; }

        public IEnumerable<DescriptionTables> dMaritalStatus { get; set; }
    }
}
