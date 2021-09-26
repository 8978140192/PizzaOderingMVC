using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PizzaOrderingMVCApplication.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            Orders = new HashSet<Order>();
        }
        [Required(ErrorMessage = "UserId cannot be empty")]
        public string UserId { get; set; }
        
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
        
        public string UserName { get; set; }
        
        public string UserPhone { get; set; }
       
        public int? UserAge { get; set; }
        
        public string UserAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
