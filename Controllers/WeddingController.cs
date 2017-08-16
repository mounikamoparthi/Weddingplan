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
        
            List<Wedding> wedd = _context.weddings
                                        .Include(wedding => wedding.Invitations)
                                        .ToList();
            ViewBag.weddings = wedd;
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
             
                return RedirectToAction("show");
            
        }
        [HttpGet]
        [Route("wedding/deletewed/{weddingid}")]
        public IActionResult deletewed(int weddingid)
        {
                Wedding weddingrecord = _context.weddings.SingleOrDefault(w => w.WeddingId == weddingid);
                _context.weddings.Remove(weddingrecord);
                _context.SaveChanges();
                return RedirectToAction("show"); 
        }

        [HttpGet]
        [Route("wedding/{WeddingId}")]
        {
            public IActionResult details(int WeddingId){

            }
        }
    }
}
        
