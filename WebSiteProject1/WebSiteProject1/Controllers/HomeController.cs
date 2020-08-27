using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WebSiteProject1.Models;

namespace WebSiteProject1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult RegisterForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplyForm(Models.Register register)
        {
            if (ModelState.IsValid)
            {
                var userRepository = new UserRepository();
                userRepository.Add(register);
                return View("RegisterConfirm", register);
            }
            else
            {
                return View("RegisterForm");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult EnrollInClass()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EnrollInClass(Models.EnrollModel enrollModel)
        {
            if (ModelState.IsValid)
            {
                var user = JsonConvert.DeserializeObject<Models.UserModel>(HttpContext.Session.GetString("User"));
                var userClassRepository = new UserClassRepository();
                userClassRepository.Add(enrollModel.ClassId, user.Id);
                var myClasses = userClassRepository.GetAll(user.Id);
                return View("StudentClasses", myClasses);
            }
            else
            {
                return View("EnrollInClass");
            }
        }

        public IActionResult Classlist()
        {
            var context = new Db.minicstructorContext();

            var classes = context.Class
                        .Include(t => t.UserClass)
                        .ThenInclude(t => t.User);

            return View(classes);
        }

        [Authorize]
        public IActionResult StudentClasses()
        {
            var userClassRepository = new UserClassRepository();
            var user = JsonConvert.DeserializeObject<Models.UserModel>(HttpContext.Session.GetString("User"));

            var myClasses = userClassRepository.GetAll(user.Id);

            return View(myClasses);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            ViewData["ReturnUrl"] = Request.Query["returnUrl"];
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userRepository = new UserRepository();
                var user = userRepository.LogIn(loginModel.UserEmail, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    var json = JsonConvert.SerializeObject(new Models.UserModel
                    {
                        Id = user.Id,
                        Name = user.Name
                    });

                    HttpContext.Session.SetString("User", json);

                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, "User"),
                };

                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = false,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = false,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        IssuedUtc = DateTimeOffset.UtcNow,
                        // The time at which the authentication ticket was issued.
                    };

                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrincipal,
                        authProperties).Wait();

                    return Redirect(returnUrl ?? "~/");
                }
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            HttpContext.Session.Remove("User");

            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("~/");
        }
    }
}