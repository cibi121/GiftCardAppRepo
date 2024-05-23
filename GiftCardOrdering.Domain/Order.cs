using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardOrdering.Domain
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int DeliveryOptionID { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CreditCardSurcharge { get; set; }
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public DeliveryOption DeliveryOption { get; set; }
        public ICollection<OrderGiftCard> OrderGiftCards { get; set; }
    }
}
