using CourierStatusSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CourierStatusSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            Login obj = new Login();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Login(Login objuserlogin)
        {
            var display = Userloginvalues().Where(m => m.Username == objuserlogin.Username && m.Password == objuserlogin.Password).FirstOrDefault();

            if (display != null)
            {
                ViewBag.Status = "CORRECT Username and Password";
                //RedirectToAction("Index", "Home");
                return Redirect("~/Home/Index");
            }
            else
            {
                ViewBag.Status = "INCORRECT Username or Password";
            }
            return View(objuserlogin);
        }

        public List<Login> Userloginvalues()
        {
            List<Login> objModel = new List<Login>();
            objModel.Add(new Login { Username = "user1", Password = "password1" });
            objModel.Add(new Login { Username = "user2", Password = "password2" });
            objModel.Add(new Login { Username = "user3", Password = "password3" });
            objModel.Add(new Login { Username = "user4", Password = "password4" });
            objModel.Add(new Login { Username = "user5", Password = "password5" });
            return objModel;
        }
    }
}

