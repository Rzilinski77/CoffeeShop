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

        //need one action to load our RegisterPage, also need a view
        public IActionResult Register()
        {
            //if no view is specified to load our Registration, also need a view
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Shop(string username)
        {
            // Use my context class to pull in my DataBase data
            ShopDBContext db = new ShopDBContext();

            // make an indiviodual Person object to store my result in
            Users matchedUser = new Users();

            // make an indiviodual Person object to store my result in
            TempData["Registered"] = false;

            // i need to find my result in my DB
            foreach (Users user in db.Users)
            {
                // as i iterate through the collection, I want to find the correct result
                if (user.Username == username)
                {
                    // if you find a match, assign that value to your temp Person object
                    matchedUser = user;
                    //you found a match, set your TempData to true
                    //this allows us to display certain HTML
                    TempData["Registered"] = true;
                }
            }
            // pass the object with the data to the view to be displayed
            return View(matchedUser);
        }
        public IActionResult PasswordError()
        {
            return View("PasswordError");
        }
        //need one action to take those user inputs, and display the user name, in a new view
        public IActionResult MakeNewUser(Users Users)
        {
            //use the RegisterTestContext object, to access the DB data
            ShopDBContext db = new ShopDBContext();

            //we use our database object, to access the table we want to write new data to
            db.Users.Add(Users);

            //we must SaveChanges that we just made to our DataBase
            db.SaveChanges();
            return View("Shop", Users);
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
