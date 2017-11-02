using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using eClub.Context;

namespace eClub.Models
{
    public class ProductComponentsViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SubProductID { get; set; }
        public int BenefitID { get; set; }
        public virtual IEnumerable<mSubProduct> ProductSubProducts { get; set; }
        public virtual IEnumerable<Benefit> ProductBenefits { get; set; }

        public ProductComponentsViewModel() { }
        public ProductComponentsViewModel(ProductComponentsViewModel productcomponent)
        {
            this.ProductID = productcomponent.ProductID;
            this.ProductName = productcomponent.ProductName;
            this.SubProductID = productcomponent.SubProductID;
            this.BenefitID = productcomponent.BenefitID;
            IEnumerable<mSubProduct> ProductSubProducts = new List<mSubProduct>();
            IEnumerable<Benefit> ProductBenefits = new List<Benefit>();
        }
    }

    public class SelectProductComponentsViewModel
    {
        public SelectProductComponentsViewModel() { }

        // Update this to accept an argument of type ApplicationRole:
        public SelectProductComponentsViewModel(mProduct product)
        {
            this.ProductID = product.mProduct_ID;
            // Assign the new Descrption property:
            this.ProductName = product.mProduct_Name;

            IEnumerable<mSubProduct> ProductSubProducts = new List<mSubProduct>();
            IEnumerable<Benefit> ProductBenefits = new List<Benefit>();
        }

        public bool Selected { get; set; }

        [Required]
        public int ProductID { get; set; }

        // Add the new Description property:
        public string ProductName { get; set; }

        public virtual IEnumerable<mSubProduct> ProductSubProducts { get; set; }
        public virtual IEnumerable<Benefit> ProductBenefits { get; set; }
    }

    public class EditProductComponentsViewModel
    {
        public int OriginalProductID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public virtual IEnumerable<mSubProduct> ProductSubProducts { get; set; }
        public virtual IEnumerable<Benefit> ProductBenefit { get; set; }

        public EditProductComponentsViewModel() { }
        public EditProductComponentsViewModel(mProduct product)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var SubProductList = new List<mSubProduct>();
            
            foreach (var subproduct in db.mSubProducts)
            {
                SubProductList.Add(subproduct);
            }

            var BenefitList = new List<Benefit>();
            foreach (var benefit in db.Benefits)
            {
                BenefitList.Add(benefit);
            }

            this.OriginalProductID = product.mProduct_ID;
            this.ProductID = product.mProduct_ID;
            this.ProductName = product.mProduct_Name;
            ProductSubProducts = SubProductList;
            ProductBenefit = BenefitList;
        }
    }
}
