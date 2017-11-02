using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace eClub.Models
{
    [Table("mClient")]
    public class Client
    {
        [Key]
        public int mClient_ID { get; set; }

        [Required]
        public string mClient_IdentityCardNumber { get; set; }

        [Required]
        public string mClient_FirstName { get; set; }

        public string mClient_MidleName { get; set; }

        [Required]
        public string mClient_LastName { get; set; }

        public string mClient_MaidenName { get; set; }

        [Column(TypeName = "date")]
        public DateTime mClient_BornDate { get; set; }

        public int mClient_ChildrenNumber { get; set; }

        public bool mClient_SendSMS { get; set; }

        public bool mClient_SendEMail { get; set; }

        public int dGender_ID { get; set; }

        public int dClientStatus_ID { get; set; }

        public int dCitizenship_ID { get; set; }

        public int dMaritalStatus_ID { get; set; }

        public int dOccupation_ID { get; set; }

        public int dClientIncomeRange_ID { get; set; }

        public int dClientSource_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime mClient_FirstContactDate { get; set; }

        public int dClientOriginalContact_ID { get; set; }

        public int SECUser_ID { get; set; }

        public ClientCreditcard ClientCC { get; set; }

        public IEnumerable<ClientEmail> mClientEmails { get; set; }
        public IEnumerable<ClientPhoneNumber> mClientPhoneNumbers{ get; set; }

        public LeadsModel Leads;
    }


    [Table("mClientEmail")]
    public class ClientEmail
    {
        public int mClient_ID { get; set; }

        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email address")]
        public string mClientEmail_Address { get; set; }

        public bool mClientEmail_IsDefault { get; set; }
    }

    [Table("mClientPhoneNumber")]
    public class ClientPhoneNumber
    {
        public int mClient_ID { get; set; }

        public string mClientPhoneNumber_PhoneNumber{ get; set; }

        public string mClientPhoneNumber_Status { get; set; }

        public bool mClientPhoneNumber_IsDefault { get; set; }
    }

    [Table("mClientCreditCard")]
    public class ClientCreditcard
    {
        [Key]
        public int mClient_ID { get; set; }
        [CreditCard]
        public string mClientCreditCard_Number { get; set; }

        public int mCardType_ID { get; set; }

        public int mIssuerBank_ID { get; set; }

        public string mClientCreditCard_HolderName { get; set; }

        public int mClientCreditCard_ExpireMonth { get; set; }

        public int mClientCreditCard_ExpireYear { get; set; }
    }

    [Table("mCardType")]
    public class CardType
    {
        [Key]
        public int mCardType_ID { get; set; }

        public string mCardType_Name { get; set; }
    }

    [Table("mIssuerBank")]
    public class IssuerBank
    {
        [Key]
        public int mIssuerBank_ID { get; set;}

        public string mIssuerBank_Name { get; set; }
    }
}
