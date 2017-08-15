using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wedding_planner.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace wedding_planner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingContext _context;
 
        public WeddingController(WeddingContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("show")]
        public IActionResult show(){
        
            List<Wedding> weddings = _context.wedding
                                        .Include(wedding => wedding.Invites)
                                        .ToList();
            ViewBag.weddings = weddings;
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            return View("show");
        }

        [HttpGet]
        [Route("/create")]
        public IActionResult create()
        {
            return View("Create");
        }
        [HttpPost]
        [Route("/Wedform")]
        public IActionResult Wedform(Wedding NewWedding)
        {
            System.Console.WriteLine("adding newwedding");
            
             var loggedUserId = HttpContext.Session.GetInt32("UserId");

            
                NewWedding.UserId = loggedUserId.Value;
            
                _context.Add(NewWedding);
                _context.SaveChanges();
             
                return RedirectToAction("show","Home");
            
        }
    }
}
        
