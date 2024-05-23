using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardOrdering.Domain
{
    // DeliveryOption.cs
    public class DeliveryOption
    {
        public int DeliveryOptionID { get; set; }
        public string DeliveryType { get; set; }
        public decimal Cost { get; set; }
    }
}
