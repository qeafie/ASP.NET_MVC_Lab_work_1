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
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }

        //[HttpGet]
        //public ActionResult SignIn()
        //{
           
          //  return View();
        //}

        [HttpPost]
        public ActionResult Index(User model, string login,string password)
        {
             
            
            if (Models.User.IsValid(login, password))
            {
                
                return View("PersonalAccount");
            }
            else {
                if (Models.User.CheckUser(login))
                {
                    return View("LoginFailed");
                }
                return View("Index");
            }
            
            
        }

       
    }
}