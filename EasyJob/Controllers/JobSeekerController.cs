using EasyJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyJob.Controllers
{
    public class JobSeekerController : Controller
    {
        private EasyJobContext db = new EasyJobContext();
        
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Recherche(JobSeekerSearchModel searchmodel)
        {
            var JobSeeker = new JobSeekerSearchLogic();
            var model = JobSeeker.GetJobSeeker(searchmodel);
            return View("Recherche",model.ToList());
        }
        public List<Ville> GetVilles()
        {
            return (from v in db.Villes
                    select v).ToList();


        }
    }
}