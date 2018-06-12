using EasyJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyJob.Controllers
{
    public class JobOfferController : Controller
    {
        private EasyJobContext db = new EasyJobContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recherche(JobOfferSearchModel searchmodel)
        {
            var JobOffer = new JobOfferSearchLogic();
            var model = JobOffer.GetJobOffer(searchmodel);
            return View("Recherche", model.ToList());
        }
       
    }
}