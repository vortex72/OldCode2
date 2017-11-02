using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace eClub.Models
{
    [Table("mBenefit")]
    public partial class Benefit
    {
        [Key]
        public int mBenefit_ID { get; set; }
 
        public string mBenefit_Name { get; set; }

        public string mBenefit_Description { get; set; }

        public int mProvider_ID { get; set; }

        public DateTime mBenefit_CreationDate { get; set; }

        public int mBenefit_StartPeriod { get; set; }

        public int mBenefit_TopBenefitByPeriod { get; set; }

        public int mBenefit_UseFrequency { get; set; }

        public bool mBenefit_WebViewable { get; set; }

        public bool mBenefit_Viewable { get; set; }

        public decimal mBenefit_EarnedDividends { get; set; }

        public int mBenefit_DividendsDuration { get; set; }

        public decimal mBenefit_DividendsMax { get; set; }

        public decimal mBenefit_DividendsMin { get; set; }

        public int dBenefitsStatus_ID { get; set; }

        public int SECUser_ID { get; set; }
    }
}
