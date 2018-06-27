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
            var BDD = db.Set<JobOffer>();
            jobOffer.Ville = db.Villes.Where(x => x.Id == jobOffer.Ville.Id).Single();
            var session = Convert.ToInt32(Session["userID"]);
            jobOffer.Company = db.Companies.Where(x => x.UserId.UserId == session).Single();

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

        // GET: JobSeekerstest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // POST: JobSeekerstest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobOffer jobOffer = db.JobOffers.Find(id);
            db.JobOffers.Remove(jobOffer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Id = new SelectList(db.Villes, "Id", "Nom");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobOffer jobOffer)
        {
            var session = Convert.ToInt32(Session["userID"]);
            
            //jobOffer.Company = db.Companies.Where(x=>x.UserId.UserId==session).Single();
            jobOffer.Ville = db.Villes.Where(x => x.Id == jobOffer.Ville.Id).Single();

            db.Entry(jobOffer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
