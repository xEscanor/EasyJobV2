using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyJob.Models;

namespace EasyJob.Controllers
{
    public class AddJobSeekersController : Controller
    {
        private EasyJobContext db = new EasyJobContext();

         public ActionResult Index()
        {
            var session = Convert.ToInt32(Session["userID"]);
            return View(db.JobSeekers.Where(x => x.Id == session).ToList());

            //var result = db.JobOffers.Where(x => x.Company.UserId == Session["userID"]).ToList();
          //  if (result == null)
            //    return View();
            //else
             //   return View(result);
        }

        public ActionResult Create()
        {
  
            return View();
        }

        [HttpPost]

        public ActionResult Create([Bind(Include = "Id,Email,Username,LastName,FirstName,BirthDay,Age,Diploma,Experience,Gender")] JobSeeker jobSeeker)
        {
            JobSeeker jobseeker = (from c in db.JobSeekers
                                  where c.Id == Convert.ToInt32(Session["userID"])
                                  select c).FirstOrDefault();
            Console.WriteLine(jobseeker.Id.ToString());
            //if (ModelState.IsValid)
            //{
            //db.JobSeekers.Add(jobSeeker);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            // }
            Console.WriteLine("oui");
            return View(jobSeeker);
        }
    }
}
