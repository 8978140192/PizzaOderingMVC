using Microsoft.EntityFrameworkCore;
using PizzaOrderingMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingMVCApplication.Services
{
    public class UserloginIRepo : IRepo
    {
        private readonly PizzaOrdingUsingMVCContext _context;
        public UserloginIRepo(PizzaOrdingUsingMVCContext context)
        {
            _context = context;
        }
        /// <summary>
        /// This add new user into userDetails database
        /// </summary>
        /// <param name="userDetail"></param>
        /// <returns>return false if user added otherwise true</returns>
        public bool AddUser(UserDetail userDetail)
        {
            try
            {
                _context.UserDetails.Add(userDetail);
                _context.SaveChanges();
                return false;
            }
            catch (DbUpdateConcurrencyException ducex)
            {
                Console.WriteLine(ducex.Message);
                return true;
            }
            catch (DbUpdateException dbuex)
            {
                Console.WriteLine(dbuex.Message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return true;

            }
        }
        /// <summary>
        /// Check autentication of user valid or not
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns>userdetails if valid user otherwise null</returns>
        public UserDetail Autorize(string userId, string password)
        {
            try
            {
                var userDetail = _context.UserDetails.Where(x => x.UserId == userId && x.Password == password).FirstOrDefault();
                return userDetail;
            }
            catch (ArgumentNullException argnulex)
            {
                Console.WriteLine(argnulex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            
        }
        /// <summary>
        /// Fetch all pizza details from database
        /// </summary>
        /// <returns>pizzaDetails</returns>

        public ICollection<PizzaDetail> GetAllPizza()
        {

            try
            {
                IList<PizzaDetail> pizzas = _context.PizzaDetails.ToList();
                if (pizzas.Count > 0)
                    return pizzas;
                else
                    return null;
            }
            catch (ArgumentNullException argnulex)
            {
                Console.WriteLine(argnulex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            
        }
        /// <summary>
        /// Store user selected pizza details
        /// </summary>
        /// <param name="button"></param>
        public void InserIntoOrders(int button)
        {
            PizzaDetail details = _context.PizzaDetails.Where(x => x.PizzaId == button).FirstOrDefault();
            CommanUsedValued.pizzaIdOfCustomer.Add(button);

            CustomerPizzaDetails customerPizzaDetails = new();

            customerPizzaDetails.pizzaDetail = GetPizzaDetailById(button);
            customerPizzaDetails.pizzaId = button;
            customerPizzaDetails.onion = false;
            customerPizzaDetails.crispCapsicum = false;
            customerPizzaDetails.GrilledMushroom = false;
            customerPizzaDetails.qty = 1;
            CommanUsedValued.customerPizzaDetail.Add(customerPizzaDetails);
        }
        /// <summary>
        /// Update the new pizza details.
        /// </summary>
        /// <param name="customerPizzaDetails"></param>
        public void UpdateNewDetails(List<CustomerPizzaDetails> customerPizzaDetails)
        {
            CommanUsedValued.customerPizzaDetail.Clear();
            foreach (var item in customerPizzaDetails)
            {
                CommanUsedValued.customerPizzaDetail.Add(item);
            }
        }
        /// <summary>
        /// Get price details of user ordered pizzas
        /// </summary>
        /// <param name="customerPizzaDetails"></param>
        /// <returns></returns>
        public List<int> PizzaOrderPriceDetails(List<CustomerPizzaDetails> customerPizzaDetails)
        {
            List<int> pizzaOrderPrices = new();
            int pizzaPrice = 0;
            int totalPrice = 0;
            foreach (var item in customerPizzaDetails)
            {
                pizzaPrice = (int)item.pizzaDetail.PizzaPrice * item.qty;
                if (item.onion == true)
                    pizzaPrice += 60 * item.qty;
                if (item.GrilledMushroom == true)
                    pizzaPrice += 60 * item.qty;
                if (item.crispCapsicum == true)
                    pizzaPrice += 60 * item.qty;
                pizzaOrderPrices.Add(pizzaPrice);
                totalPrice += pizzaPrice;

            }
            pizzaOrderPrices.Add(totalPrice);
            return pizzaOrderPrices;
        }
        /// <summary>
        /// Insert data into orders table
        /// </summary>
        /// <param name="status"></param>
        void InserIntoOrderTable(string status)
        {
            if (CommanUsedValued.insertingCount == 0)
            {
                CommanUsedValued.insertingCount++;
                Order order = new Order();
                order.UserId = CommanUsedValued.CurrentUsserId;
                order.DeliveryCharges = 0;
                order.TotalBill = 0;
                order.Quatity = CommanUsedValued.orderQuatity;
                order.OrderStatus = status;
                _context.Orders.Add(order);
                _context.SaveChanges();
                CommanUsedValued.CurrentOrderId = order.OrderId;
            }

           

        }
        /// <summary>
        /// Insert data into orderdetails table and topping details
        /// </summary>
        /// <param name="customerPizzaDetails"></param>
        /// <param name="status"></param>
        
        public void UpdateDatabase(List<CustomerPizzaDetails> customerPizzaDetails, string status)
        {
            InserIntoOrderTable(status);
            CommanUsedValued.orderTotalBill = 0;
            foreach (var item in customerPizzaDetails)
            {
                for (int i = 0; i < item.qty; i++)
                {
                    PizzaDetail details = _context.PizzaDetails.Where(x => x.PizzaId == item.pizzaId).FirstOrDefault();
                    CommanUsedValued.orderTotalBill += (int)details.PizzaPrice;

                    InserIntoOrderDetail(CommanUsedValued.CurrentOrderId, item.pizzaId);
                    if (item.onion == true)
                    {
                        CommanUsedValued.orderTotalBill += 60;
                        InserIntoTopping(CommanUsedValued.CurrentOrderDetailId, 1);
                    }
                    if (item.crispCapsicum == true)
                    {
                        CommanUsedValued.orderTotalBill += 60;
                        InserIntoTopping(CommanUsedValued.CurrentOrderDetailId, 2);
                    }
                    if (item.GrilledMushroom == true)
                    {
                        CommanUsedValued.orderTotalBill += 60;
                        InserIntoTopping(CommanUsedValued.CurrentOrderDetailId, 3);

                    }


                }

                CommanUsedValued.orderQuatity += item.qty;

            }
            UpdateOrderDatabase(CommanUsedValued.orderQuatity, CommanUsedValued.orderTotalBill, status);
            customerPizzaDetails.Clear();
            CommanUsedValued.insertingCount = 0;
            CommanUsedValued.orderTotalBill = 0;
            CommanUsedValued.orderQuatity = 0;
            CommanUsedValued.pizzaIdOfCustomer.Clear();
            CommanUsedValued.customerPizzaDetail.Clear();
        }

        /// <summary>
        /// Insert data into topping details
        /// </summary>
        /// <param name="currentOrderDetailId"></param>
        /// <param name="toppindId"></param>

        private void InserIntoTopping(int currentOrderDetailId, int toppindId)
        {
            OrderToppingDetail orderToppingDetail = new();
            orderToppingDetail.ItemId = currentOrderDetailId;
            orderToppingDetail.ToppingId = toppindId;
            _context.OrderToppingDetails.Add(orderToppingDetail);
            _context.SaveChanges();


        }
        /// <summary>
        /// Insert data into order details tables
        /// </summary>
        /// <param name="currentOrderId"></param>
        /// <param name="pizzaId"></param>
        private void InserIntoOrderDetail(int currentOrderId, int pizzaId)
        {
            OrderDetail orderDetail = new();
            orderDetail.PizzaId = pizzaId;
            orderDetail.OrderId = currentOrderId;
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            CommanUsedValued.CurrentOrderDetailId = orderDetail.ItemId;
        }



        private void UpdateOrderDatabase(int orderQty, int orderTotalBill, string status)
        {
            Order UpdatedOderder = _context.Orders.First(i => i.OrderId == CommanUsedValued.CurrentOrderId);
            UpdatedOderder.TotalBill = orderTotalBill;
            UpdatedOderder.Quatity = orderQty;
            if (orderTotalBill > 250)
            {
                UpdatedOderder.DeliveryCharges = 0;
            }
            else
            {
                UpdatedOderder.DeliveryCharges = 25;

            }
            UpdatedOderder.OrderStatus = status;
            _context.SaveChanges();
        }
        /// <summary>
        /// Fetch pizza details by pizza id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public PizzaDetail GetPizzaDetailById(int id)
        {
            PizzaDetail details = _context.PizzaDetails.Where(x => x.PizzaId == id).FirstOrDefault();
            return details;
        }
        /// <summary>
        /// Fetch user details by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserDetail GetUserDetailsById(string userId)
        {
            UserDetail userDetail = _context.UserDetails.Where(x => x.UserId == userId).FirstOrDefault();
            return userDetail;
        }
    }
}