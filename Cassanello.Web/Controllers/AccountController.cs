using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyVet.Web.Models;

namespace Cassanello.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel modelo)
        {
            if (!ModelState.IsValid)
            {


            }
            return View(modelo);

        }



    }
}
