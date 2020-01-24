using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //need one action to load our RegistrationPage, also need a view
        public IActionResult Registration()
        {
            //if no view is specified to load our Registration, also need a view
            return View();
        }
        public IActionResult PasswordError()
        {
            return View("PasswordError");
        }
        //need one action to take those user inputs, and display the user name, in a new view
        public IActionResult Welcome(
            string firstname,
            string lastname,
            string email,
            string phonenumber,
            string phonetype,
            string username, 
            string password, 
            string passwordtwo)
        {
            ViewBag.FirstName = firstname;
            ViewBag.LastName = lastname;
            ViewBag.Email = email;
            ViewBag.UserName = username;

            if (password == passwordtwo)
            {
                return View();
            }
            else
            {
                return PasswordError();
            }


        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
