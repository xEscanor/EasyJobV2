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
    public class AddJobOfferController : Controller
    {
        private EasyJobContext db = new EasyJobContext();

        public ActionResult Index()
        {
            var session = Convert.ToInt32(Session["userID"]);
            return View(db.JobOffers.Where(x => x.Company.UserId.UserId == session).ToList());

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
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobOffer jobOffer)
        {
            //if(jobOffer.Diploma != "")
            // {
            // db.JobOffers.Add(jobOffer);
            // db.SaveChanges();
            // return RedirectToAction("Index");
            // }
            // return View(jobOffer);

            var foa = db.FieldOfActivities.OrderBy(m=>m.Nom).ToList();
            ViewBag.ListFOA = new SelectList(foa,"test","test");

            var BDD = db.Set<JobOffer>();
            var BDD2 = db.Set<Company>();

            var session = Convert.ToInt32(Session["userID"]);
            jobOffer.Company = db.Companies.Where(x => x.UserId.UserId == session).Single();
            jobOffer.FieldOfActivity = db.FieldOfActivities.Where(x => x.Nom.Equals(jobOffer.FieldOfActivity)).Single();
            jobOffer.Ville = db.Villes.Where(x => x.Nom.Equals(jobOffer.Ville)).Single();
            BDD.Add(jobOffer);
            db.SaveChanges();

            ViewBag.SuccesMessage = "Registration successful";
            return View(viewName: "Create", model: new JobOffer());

        }
    }
}
