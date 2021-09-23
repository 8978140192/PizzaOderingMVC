using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaOrderingMVCApplication.Models
{
    public partial class PizzaDetail
    {
        public PizzaDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int? PizzaPrice { get; set; }
        public string PizzaDiscription { get; set; }
        public string PizzaImage { get; set; }
        public string PizzaType { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
