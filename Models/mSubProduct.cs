namespace eClub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mSubProduct")]
    public partial class mSubProduct
    {
        [Key]
        public int mSubProduct_ID { get; set; }

        [Required]
        [StringLength(150)]
        public string mSubProduct_Name { get; set; }

        [Column(TypeName = "money")]
        public decimal mSubProduct_PaymentAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal mSubProduct_PaymentAmountExoneration { get; set; }

        public DateTime mSubProduct_CreationDate { get; set; }

        public DateTime mSubProduct_StartDate { get; set; }

        public DateTime mSubProduct_EndDate { get; set; }

        public int mSubProduct_MaxProductAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? mSubProduct_EarnedDividends { get; set; }

        public bool? mSubProduct_BeneficiariesAllowed { get; set; }

        public int? mSubProduct_MinAgeAllowed { get; set; }

        public int? mSubProduct_MaxAgeAllowed { get; set; }

        public int mSubProduct_Status { get; set; }

        [Column(TypeName = "money")]
        public decimal? mSubProduct_MaxDividends { get; set; }

        [Column(TypeName = "money")]
        public decimal? mSubProduct_MinDividends { get; set; }

        public int? mSubProduct_DividendsDuration { get; set; }

        public int? mProvider_ID { get; set; }

        public bool? mSubProduct_WebViewable { get; set; }

        public int SECUSer_ID { get; set; }
    }
}
