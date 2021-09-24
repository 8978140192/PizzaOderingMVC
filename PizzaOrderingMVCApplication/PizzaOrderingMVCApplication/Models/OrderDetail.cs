using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaOrderingMVCApplication.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            OrderToppingDetails = new HashSet<OrderToppingDetail>();
        }

        public int ItemId { get; set; }
        public int? PizzaId { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual PizzaDetail Pizza { get; set; }
        public virtual ICollection<OrderToppingDetail> OrderToppingDetails { get; set; }
    }
}
