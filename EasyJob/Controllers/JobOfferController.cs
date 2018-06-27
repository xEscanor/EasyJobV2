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
            int user = (int)Session["userId"];
            var jobseekerid = (from p in db.JobSeekers where p.UserId.UserId == user select p.Id).FirstOrDefault();


            var JobOffer = new JobOfferSearchLogic();
            var model = JobOffer.GetJobOffer(searchmodel,jobseekerid);
            return View("Recherche", model.ToList());
        }
        public void Like(int id)
        {
            int user = (int)Session["userId"];
            var jobseekerid = (from p in db.JobSeekers where p.UserId.UserId ==user  select p.Id).FirstOrDefault();
          
     
            var test = from p in db.ClikeJSs
                       where (p.JobOfferId == id)
                       && (p.JobSeekerId == jobseekerid)
                       select p.JobSeekerId ;

            int result = 0;

            foreach (int element in test)
            {
                result = element;
            };

            if (result == 0)
            {
                System.Diagnostics.Debug.WriteLine(id);
                var BDD = db.Set<JSlikeJO>();
                BDD.Add(new JSlikeJO(true,jobseekerid, id));
                db.SaveChanges();
            }
            else
            {
                //indique quand même le like

                System.Diagnostics.Debug.WriteLine(id);
                var BDD = db.Set<JSlikeJO>();
                BDD.Add(new JSlikeJO(true, jobseekerid, id));
                db.SaveChanges();

                //realise le match

                System.Diagnostics.Debug.WriteLine(id);
                var BDD2 = db.Set<Match>();
                BDD2.Add(new Match(id, jobseekerid));
                db.SaveChanges();
            }
        }

        public void Dislike(int id)
        {
            int user = (int)Session["userId"];
            var jobseekerid = (from p in db.JobSeekers where p.UserId.UserId == user select p.Id).FirstOrDefault();


            System.Diagnostics.Debug.WriteLine(id);
            var BDD = db.Set<JSlikeJO>();
            BDD.Add(new JSlikeJO(false, jobseekerid, id));
            db.SaveChanges();
        }

   
    }
}