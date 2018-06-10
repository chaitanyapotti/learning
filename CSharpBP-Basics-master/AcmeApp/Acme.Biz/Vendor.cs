using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        public enum IncludeAddress {  yes, no };
        public enum SendCopy { yes, no };

        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product">Product to Order</param>
        /// <param name="quantity">Quantity of product to Order</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity) => PlaceOrder(product, quantity, deliverBy: null);
        /// <summary>
        /// Sends a Product Order to the vendor
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="quantity">Quantity of the product to order</param>
        /// <param name="deliverBy">Rquested delivery date</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity,DateTimeOffset? deliverBy)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            var success = false;

            var orderText = "Order from Acme, Inc" + Environment.NewLine + "Product: " + product.ProductCode + Environment.NewLine +
                "Quantity: " + quantity;
            if (deliverBy.HasValue) orderText += Environment.NewLine + "Deliver By: " + deliverBy.Value.ToString("d");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            //if (confirmation.StartsWith("Message sent:")) success = true;

            success = (confirmation.StartsWith("Message sent: ")) ? true : false;

            OperationResult.MyProperty.Success = success;
            OperationResult.MyProperty.Message = orderText;
            return OperationResult.MyProperty;
        }
        /// <summary> 
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <param name="message">Message can be anything</param>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).TrimEnd();
            var confirmation = emailService.SendMessage(subject,
                                                        message,
                                                        this.Email);
            return confirmation;
        }

        public override string ToString() => ($"Vendor: {CompanyName}");

        public object PlaceOrder(Product product, int quantity, string instructions)
        {
            throw new NotImplementedException();
        }
    }
}
