using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingMVCApplication.Models
{
    public class CustomerPizzaDetails
    {
        public int pizzaCount { get; set; }
        public int pizzaId { get; set; }
        public bool onion { get; set; }
        public bool crispCapsicum  { get; set; }
        public bool GrilledMushroom { get; set; }
        public int qty { get; set; }

       
    }
}
