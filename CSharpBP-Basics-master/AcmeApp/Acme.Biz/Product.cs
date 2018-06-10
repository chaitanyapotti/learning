using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory
    /// </summary>
    public class Product : IEquatable<Product>
    {
        public Product()
        {
            Console.WriteLine("Product instance created");
            //this.ProductVendor = new Vendor();
            this.Category = "Tools";
        }
        public Product(int productId, string productName, string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;


            string abc = "";
            int i = 10;
            abc = i == 10 ? "xys" : "lll";

            Console.WriteLine("Product instance has a name: " + ProductName);
        }
        private string productName;

        public string ProductName
        {
            get
            {
                return productName?.Trim();
                //return productName;
            }
            set { productName = value; }
        }
        public decimal Cost { get; set; }

        public string Description { get; set; }


        public string ProductDescription => Description + " " + ProductName;

        public int ProductId { get; set; }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get
            {
                //if (productVendor == null)
                //{
                //    //Lazy Loading
                //    productVendor = new Vendor();
                //} 
                //return productVendor;
                //productVendor?.GetHashCode();
                return productVendor ?? (productVendor = new Vendor());
            }
            set { productVendor = value; }
        }

        public string ProductCode => Category + "-" + SequenceNumber;
        public string VendorName => ProductVendor?.CompanyName;

        public string Category { get; set; }

        public int SequenceNumber { get; set; } = 1;
        public object ValidationMessage { get; set; }

        public decimal CalculateSuggestedPrice(decimal markupPercent) => this.Cost * (1 + markupPercent / 100);

        public override string ToString() => ProductName + " (" + ProductId + ")";

        /// <summary>
        /// Says Hello
        /// </summary>
        /// <returns>The Hello string</returns>
        public string SayHello()
        {
            var vendor = new Vendor();
            vendor.SendWelcomeEmail("Message sent");
            var emailService = new EmailService();
            return "Hello " + ProductName + " (" + ProductId + "): " + Description;
        }
        /// <summary>
        /// Overrides the default Equals method for Product Class
        /// </summary>
        /// <param name="other">Product object to compare against</param>
        /// <returns>Whether the objects are equal or not</returns>
        public virtual bool Equals(Product other)
        {
            return (this.Category == other.Category && this.ProductCode == other.ProductCode && this.ProductVendor.VendorId == other.ProductVendor.VendorId);
            //throw new NotImplementedException();
        }
    }
}
