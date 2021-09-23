using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaOrderingMVCApplication.Models
{
    public partial class ToppingDetail
    {
        public ToppingDetail()
        {
            OrderToppingDetails = new HashSet<OrderToppingDetail>();
        }

        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public double? ToppingPrice { get; set; }

        public virtual ICollection<OrderToppingDetail> OrderToppingDetails { get; set; }
    }
}
