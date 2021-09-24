using Microsoft.AspNetCore.Mvc;
using PizzaOrderingMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingMVCApplication.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly PizzaOrdingUsingMVCContext _context;
        public UserLoginController(PizzaOrdingUsingMVCContext context)
        {
            _context = context;
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
                var userDetail = _context.UserDetails.Where(x => x.UserId == user.UserId && x.Password == user.Password).FirstOrDefault();
                if (userDetail != null)
                {

                    return RedirectToAction("Index", "Home");

                }


            }
            return View();
        }

        public IActionResult RegisterPage()
        {
            return View();
        }
    }
}
