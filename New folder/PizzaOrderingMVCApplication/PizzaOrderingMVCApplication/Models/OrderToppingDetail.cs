using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaOrderingMVCApplication.Models
{
    public partial class OrderToppingDetail
    {
        public int ItemId { get; set; }
        public int ToppingId { get; set; }

        public virtual OrderDetail Item { get; set; }
        public virtual ToppingDetail Topping { get; set; }
    }
}
