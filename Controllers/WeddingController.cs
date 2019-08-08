using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingPlannerContext dbContext;
        private const string ID = "id";

        public WeddingController(WeddingPlannerContext context)
        {
            dbContext = context;
        }

        [HttpGet("/weddings")]
        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32(ID);
            if (id.HasValue)    // check id is in session
            {
                var weddings = dbContext.GetWeddings(id.Value);

                return View("ViewAllWeddings", weddings);
            }
            else
            {
                return Redirect("/logout");
            }
        }

        [HttpGet("/weddings/new")]
        public IActionResult NewWeddingForm()
        {
            int? id = HttpContext.Session.GetInt32(ID);
            if (id.HasValue)    // check id is in session
            {
                return View("CreateWedding");
            }
            else
            {
                return Redirect("/logout");
            }
        }

        [HttpPost("/weddings/new")]
        public IActionResult CreateNewWedding(Wedding wedding)
        {
            int? id = HttpContext.Session.GetInt32(ID);
            if (id.HasValue)    // check id is in session
            {
                if (ModelState.IsValid)
                {
                    dbContext.InsertWedding(wedding, id.Value);

                    return RedirectToAction("UpdateWeddingForm", new { wid = wedding.WeddingId });
                }
                else
                {
                    return View("CreateWedding");
                }
            }
            else
            {
                return Redirect("/logout");
            }
        }

        // [HttpGet("/weddings/couples/new")]
        // public IActionResult AddWedderForm()
        // {
        //     int? id = HttpContext.Session.GetInt32(ID);
        //     if (id.HasValue)    // check id is in session
        //     {
        //         return View("AddCoupleForm");
        //     }
        //     else
        //     {
        //         return Redirect("/logout");
        //     }
        // }

        // [HttpPost("/weddings/couples/new")]
        // public IActionResult AddWedders()
        // {
        //     int? id = HttpContext.Session.GetInt32(ID);
        //     if (id.HasValue)    // check id is in session
        //     {
        //         return RedirectToAction("ViewAll");
        //     }
        //     else
        //     {
        //         return Redirect("/logout");
        //     }
        // }

        [HttpGet("/weddings/{wid}")]
        public IActionResult UpdateWeddingForm(int wid)
        {
            int? id = HttpContext.Session.GetInt32(ID);
            if (id.HasValue)    // check id is in session
            {
                var wedding = dbContext.GetWedding(wid);

                return View("UpdateWeddingForm", wedding);
            }
            else
            {
                return Redirect("/logout");
            }
        }

        [HttpPost("/weddings/{wid}/edit")]
        public IActionResult UpdateWedding(Wedding wedding, int wid)
        {
            int? id = HttpContext.Session.GetInt32(ID);
            if (id.HasValue)    // check id is in session
            {
                if (ModelState.IsValid)
                {
                    dbContext.UpdateWedding(wedding);
                    return RedirectToAction("UpdateWeddingForm", new { wid = wid });
                }
                else
                {
                    return View("UpdateWeddingForm", wedding);
                }
            }
            else
            {
                return Redirect("/logout");
            }
        }

        [HttpGet("/weddings/{wid}/vendors/new")]
        public IActionResult NewVendorForm(int wid)
        {
            int? id = HttpContext.Session.GetInt32(ID);
            if (id.HasValue)    // check id is in session
            {
                ViewBag.WeddingId = wid;
                return View("NewVendorForm");
            }
            else
            {
                return Redirect("/logout");
            }
        }

        [HttpPost("/weddings/{wid}/vendors/new")]
        public IActionResult AddNewVendor(Vendor vendor, int wid)
        {
            int? id = HttpContext.Session.GetInt32(ID);
            if (id.HasValue)    // check id is in session
            {
                if (ModelState.IsValid)
                {
                    dbContext.AddNewVendor(vendor, wid);

                    return RedirectToAction("UpdateWeddingForm", new { wid = wid });
                }
                else
                {
                    ViewBag.WeddingId = wid;
                    return View("NewVendorForm");
                }
            }
            else
            {
                return Redirect("/logout");
            }
        }

        [HttpPost("/weddings/{wid}/vendors/{vid}/edit")]
        public IActionResult UpdateVendor(Vendor vendor, int wid, int vid)
        {
            int? id = HttpContext.Session.GetInt32(ID);
            if (id.HasValue)    // check id is in session
            {
                return RedirectToAction("UpdateWeddingForm", new { wid = wid });
            }
            else
            {
                return Redirect("/logout");
            }
        }



    }
}