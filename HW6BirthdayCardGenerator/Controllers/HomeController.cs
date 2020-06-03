using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HW6BirthdayCardGenerator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomForm(Models.CustomData customData)
        {
            if (ModelState.IsValid)
            {
                return View("BirthdayCardSent", customData);
            }
            else
            {
                return View("Index");
            }
        }
    }

}