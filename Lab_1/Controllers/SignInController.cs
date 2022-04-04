using Lab_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_1.Controllers
{
    public class SignInController : Controller
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
                return View("Index");
            }
            else
                //return View("PersonalAccount",Models.User.GetUser(login));
                return View("PersonalAccount");
        }

       
    }
}