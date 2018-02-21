using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult AddUser(string firstName, string lastName, string emailAddress, string phoneNumber, string password)
        {
            bool validation = true;
            if(!Regex.IsMatch(firstName, "^[A-Z]"))
            {
                ViewBag.InputError = "That doesn't look like a name to me!";
                validation = false;
            }
            if(!Regex.IsMatch(emailAddress, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                ViewBag.InputError = "Doesn't seem like a valid email to me";
                validation = false;
            }
            if(!Regex.IsMatch(phoneNumber, @"^\d{10}$"))
            {
                ViewBag.InputError = "Do you even have a phone?";
                validation = false;
            }
            if (password.Length < 7)
            {
                ViewBag.InputError = "That password isn't long enough!";
                validation = false;
            }
            if (validation == false)
                return View("Register");
            else
            {
                ViewBag.RegisterNewUser = $"Hello, {firstName}!";
                return View();
            }
        }
    }
}