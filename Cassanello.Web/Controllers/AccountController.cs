using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Cassanello.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cassanello.Web.Controllers
{
    public class AccountController : Controller
    {       

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    }
}
