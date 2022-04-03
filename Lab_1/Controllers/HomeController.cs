using Lab_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User response, string login,string password)
        {
            if (!Models.User.IsValid(login, password))
            {
                Console.WriteLine("post  fail");
                return View("Index");
            }
            else
                return View("Success",Models.User.GetUser(login));
        }

       
    }
}