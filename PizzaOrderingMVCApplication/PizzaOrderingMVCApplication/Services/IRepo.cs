using PizzaOrderingMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingMVCApplication.Services
{
    public interface IRepo
    {
        public UserDetail Autorize(string userId, string password);
        public bool  AddUser(UserDetail userDetail);
        public ICollection<PizzaDetail> GetAllPizza();
        public void InserIntoOrders(int button);
        public void UpdateDatabase(List<CustomerPizzaDetails> customerPizzaDetails, string status);
        public void UpdateNewDetails(List<CustomerPizzaDetails> customerPizzaDetails);
        public PizzaDetail GetPizzaDetailById(int id);
        public List<int> PizzaOrderPriceDetails(List<CustomerPizzaDetails> customerPizzaDetails);


    }
}
