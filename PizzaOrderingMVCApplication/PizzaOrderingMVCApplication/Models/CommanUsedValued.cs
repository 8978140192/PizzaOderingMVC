using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingMVCApplication.Models
{
    public static class CommanUsedValued
    {
        public static string CurrentUsserId { get; set; }
        public static int CurrentOrderId { get; set; }
        public static int CurrentOrderDetailId { get; set; }
        public static int orderTotalBill { get; set; }
        public static double orderDeliveryCharges = 25;
        
        public static int orderQuatity { get; set; }
        public static string currentOrderStatus { get; set; }
        public static int insertingCount = 0;

        public static List<int> pizzaIdOfCustomer = new();
        public static List<CustomerPizzaDetails> customerPizzaDetail=new();
    }
}
