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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            var BDD = db.Set<Company>();

            var session = Convert.ToInt32(Session["userID"]);
            company.UserId = db.Users.Where(x => x.UserId == Convert.ToInt32(Session["userID"])).Single();
            company.VilleId = db.Villes.Where(x => x.Id == company.VilleId.Id).Single();
            BDD.Add(company);
            db.SaveChanges();

            ViewBag.SuccesMessage = "Registration successful";
            return View(viewName: "Create", model: new JobOffer());
        }


    }
}