using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wedding_planner.Models;
using System.Linq;

namespace wedding_planner.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext _context;
 
        public HomeController(WeddingContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid){
                User NewUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailId = model.EmailId,
                    Password = model.Password,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                   
                };
 
        // Handle success
               
                System.Console.WriteLine("Came here");
                _context.Add(NewUser);
                _context.SaveChanges();
                System.Console.WriteLine("Done adding to DB");
                User EnteredPerson = _context.user.SingleOrDefault(user => user.EmailId == model.EmailId);
                HttpContext.Session.SetString("FirstName", EnteredPerson.FirstName);
                HttpContext.Session.SetInt32("UserId",EnteredPerson.UserId);
                return RedirectToAction("show","Wedding");
            }
            else 
            {
                ViewBag.errors = ModelState.Values;
                 ViewBag.Errors = new List<string>();
                return View("Index");
            }
        }
        [HttpPost]
        [Route("PostLogin")]
        public IActionResult PostLogin(string EmailId, string Password)
        {
             User loggedUser = _context.user.SingleOrDefault(user => user.EmailId == EmailId);
             if (loggedUser != null)
             {
                HttpContext.Session.SetString("FirstName", loggedUser.FirstName);
                HttpContext.Session.SetInt32("UserId", loggedUser.UserId);
                return RedirectToAction("show","Wedding");
             }

               ViewBag.Errors = new List<string>(){ "Check Username and password"};
                return View("Index");
        }
       
    }
}
