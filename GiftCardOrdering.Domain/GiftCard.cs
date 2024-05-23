using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardOrdering.Domain
{
    public class GiftCard
    {
        public int GiftCardID { get; set; }
        public decimal FaceValue { get; set; }
        public string Message { get; set; }
        public decimal ServiceCost { get; set; }
    }
}
