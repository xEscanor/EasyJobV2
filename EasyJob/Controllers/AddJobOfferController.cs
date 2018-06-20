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
            ViewBag.Id = new SelectList(db.Villes, "Id", "Nom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobOffer jobOffer)
        {
            jobOffer.Ville = db.Villes.Where(x => x.Id == jobOffer.Ville.Id).Single();
            var BDD = db.Set<JobOffer>();
           //var BDD2 = db.Set<Company>()

            var session = Convert.ToInt32(Session["userID"]);
            jobOffer.Company = db.Companies.Where(x => x.UserId.UserId == session).Single();
            
            //if(ModelState.IsValid)
            BDD.Add(jobOffer);
            db.SaveChanges();
            ViewBag.SuccesMessage = "Registration successful";
            return RedirectToAction("Index", "AddJobOffer");

        }

        public ActionResult Selectionner(int id)
        {
            Session["offreId"] = id;
            return RedirectToAction("Index", "JobSeeker");
        }
    }
}
