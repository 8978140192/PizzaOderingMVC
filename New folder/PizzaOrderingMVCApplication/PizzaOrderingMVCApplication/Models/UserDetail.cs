using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaOrderingMVCApplication.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            Orders = new HashSet<Order>();
        }

        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public int? UserAge { get; set; }
        public string UserAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
