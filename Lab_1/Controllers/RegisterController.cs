﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.Models;

namespace Lab_1.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (true)
            {
                Lab_1.Models.User.SetUser(user);
                return View("RegisterSuccess", User);
            }
            else {
                return View();
            }
            
        }
    }
}