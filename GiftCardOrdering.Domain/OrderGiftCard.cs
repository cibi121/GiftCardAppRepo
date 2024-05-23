using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardOrdering.Domain
{
    public class OrderGiftCard
    {
        public int OrderGiftCardID { get; set; }
        public int OrderID { get; set; }
        public int GiftCardID { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public GiftCard GiftCard { get; set; }
    }
}
