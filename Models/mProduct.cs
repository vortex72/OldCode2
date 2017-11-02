namespace eClub.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("mProduct")]
    public partial class mProduct
    {
        [Key]
        public int mProduct_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string mProduct_Name { get; set; }

        public int mProduct_Status { get; set; }

        [Column(TypeName = "money")]
        public decimal mProduct_MembershipUniqueFee { get; set; }

        [Column(TypeName = "money")]
        public decimal mProduct_MembershipUniqueFeeExoneration { get; set; }

        [Column(TypeName = "money")]
        public decimal mProduct_PaymentAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal mProduct_PaymentAmountExoneration { get; set; }

        public int dPaymentFrequency_ID { get; set; }

        public int? mProduct_MaxProductAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal mProduct_EarnedDividends { get; set; }

        public DateTime mProduct_CreationDate { get; set; }

        public int? mProvider_ID { get; set; }

        public int? mProduct_DividendsDuration { get; set; }

        public bool? mProduct_WebViewable { get; set; }

        [Column(TypeName = "date")]
        public DateTime? mProduct_StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? mProduct_EndDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? mProduct_MinDividends { get; set; }

        [Column(TypeName = "money")]
        public decimal? mProduct_MaxDividends { get; set; }

        public int SECUSer_ID { get; set; }
    }

}
