using Microsoft.AspNetCore.Mvc;
using PizzaOrderingMVCApplication.Models;
using PizzaOrderingMVCApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingMVCApplication.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IRepo _repo;
        public UserLoginController(IRepo repo)
        {
            _repo = repo;
        }
        public IActionResult StartPage()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]


        public IActionResult LoginPage(UserDetail user)
        {
            if (ModelState.IsValid)
            {

                if (_repo.Autorize(user.UserId, user.Password) != null)
                {
                    CommanUsedValued.CurrentUsserId = user.UserId;

                    return RedirectToAction("PizzaView", "UserLogin");

                }


            }
            return View();
        }

        public IActionResult RegisterPage()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterPage(UserDetail userDetail)
        {
            bool userAdd = _repo.AddUser(userDetail);
            if (userAdd == false)
            {
                return RedirectToAction("LoginPage", "UserLogin");
            }
            else
            {
                ViewBag.message = "User already there or enter correct email format";
            }
            return View();
        }

        public IActionResult PizzaView()
        {
            return View(_repo.GetAllPizza());
        }
        //[HttpPost]
        public IActionResult check(int button)
        {
            _repo.InserIntoOrders(button);
            return RedirectToAction("PizzaView");
        }
        public IActionResult PizzaDetailsPage()
        {

            return View(CommanUsedValued.customerPizzaDetail);
        }
        [HttpPost]
        public IActionResult PizzaDetailsPage(List<CustomerPizzaDetails> customerPizzaDetails)
        {
            if (ModelState.IsValid)
            {
                int count = 0;
                foreach (var item in customerPizzaDetails)
                {

                    //item.pizzaCount;
                    item.pizzaId = CommanUsedValued.pizzaIdOfCustomer[count];
                    item.pizzaDetail = _repo.GetPizzaDetailById(CommanUsedValued.pizzaIdOfCustomer[count]);
                    count++;

                }
                _repo.UpdateNewDetails(customerPizzaDetails);
                //_repo.UpdateDatabase(customerPizzaDetails);
            }

            return RedirectToAction("SummaryPage", "UserLogin");
        }

        public IActionResult SummaryPage()
        {

            return View(CommanUsedValued.customerPizzaDetail);
        }
        public IActionResult ConformOrder()
        {
            _repo.UpdateDatabase(CommanUsedValued.customerPizzaDetail, "SUCESS");
            return RedirectToAction("OrderSucessPage", "UserLogin"); ;
        }
        public IActionResult CancleOrder()
        {
            _repo.UpdateDatabase(CommanUsedValued.customerPizzaDetail, "FAIL");
            return RedirectToAction("PizzaView", "UserLogin"); ;
        }
        public IActionResult OrderSucessPage()
        {
            return View();
        }
    }
}