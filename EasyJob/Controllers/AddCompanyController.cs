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
    public class AddCompanyController : Controller
    {
        private EasyJobContext db = new EasyJobContext();

        public ActionResult Index()
        {
            var session = Convert.ToInt32(Session["userID"]);
            //return View(db.JobOffers.Where(x => x.Company.UserId.UserId == session).ToList());

            return View(db.Companies.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Villes, "Id", "Nom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            var BDD = db.Set<Company>();
            
            var session = Convert.ToInt32(Session["userID"]);
            company.UserId = db.Users.Where(x => x.UserId == session).Single();
            company.VilleId = db.Villes.Where(x => x.Id == company.VilleId.Id).Single();
            BDD.Add(company);
            db.SaveChanges();

            var bdd2 = db.Set<User>();
            var result = bdd2.SingleOrDefault(b => b.UserId==session);
            if (result != null)
            {
                result.FirstConnexion = false;
                db.SaveChanges();
            }


            ViewBag.SuccesMessage = "Registration successful";
            return RedirectToAction("Index", "AddCompany");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: JobSeekerstest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}