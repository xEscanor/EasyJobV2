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
            var model = JobSeeker.GetJobSeeker(searchmodel, (int)Session["offreId"]);
            return View("Recherche", model.ToList());
        }
        public void Like(int id)
        {
            int offreid = (int)Session["offreId"];
            var test = from p in db.JSlikeCs
                       where (p.JobSeekerId==id) 
                       && (p.JobOfferId== offreid)
                       select p.JobSeekerId;

            int result=0;

            foreach (int element in test)
            {
               result=element;
            };

            if (result==0)
            {
                System.Diagnostics.Debug.WriteLine(id);
                var BDD = db.Set<ClikeJS>();
                BDD.Add(new ClikeJS(true, (int)Session["offreId"], id));
                db.SaveChanges();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(id);
                var BDD = db.Set<ClikeJS>();
                BDD.Add(new ClikeJS(true, (int)Session["offreId"], id));
                db.SaveChanges();

                //realise le match

                System.Diagnostics.Debug.WriteLine(id);
                var BDD2 = db.Set<Match>();
                BDD2.Add(new Match((int)Session["offreId"], id));
                db.SaveChanges();
            }
        }

        public void Dislike(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            var BDD = db.Set<ClikeJS>();
            BDD.Add(new ClikeJS(false, (int)Session["offreId"], id));
            db.SaveChanges();
        }

        /* Plus utilisé dus au clic qui est bloqué 
         
        public void Match(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            var BDD = db.Set<Match>();
            BDD.Add(new Match((int)Session["offreId"], id));
            db.SaveChanges();
        }
        */
    }
}