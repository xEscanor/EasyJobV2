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
            return View(db.JobSeekers.Where(x => x.UserId.UserId == session).ToList());
        }

        //var result = db.JobOffers.Where(x => x.Company.UserId == Session["userID"]).ToList();
        //  if (result == null)
        //    return View();
        //else
        //   return View(result);
        // }

        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Villes, "Id", "Nom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobSeeker jobseeker)
        {
            var BDD = db.Set<JobSeeker>();
            var session = Convert.ToInt32(Session["userID"]);
            jobseeker.UserId = db.Users.Where(x => x.UserId == session).Single();
            jobseeker.Ville = db.Villes.Where(x => x.Id == jobseeker.Ville.Id).Single();
            BDD.Add(jobseeker);
            db.SaveChanges();
            ViewBag.SuccesMessage = "Registration successful";
            return RedirectToAction("Index", "AddJobSeekers");
        }
    }
}
