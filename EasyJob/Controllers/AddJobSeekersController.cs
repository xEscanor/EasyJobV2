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

        public ActionResult Edit(int? id)
        {
            ViewBag.Id = new SelectList(db.Villes, "Id", "Nom");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobSeeker jobSeeker)
        {
            var session = Convert.ToInt32(Session["userID"]);
            jobSeeker.UserId = db.Users.Where(x => x.UserId == session).Single();
            jobSeeker.Ville = db.Villes.Where(x => x.Id == jobSeeker.Ville.Id).Single();

                db.Entry(jobSeeker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

        }
    }
}
