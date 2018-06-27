using EasyJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyJob.Controllers
{
    public class MatchesController : Controller
    {
        private EasyJobContext db = new EasyJobContext();
        // GET: Matches
        public ActionResult IndexJs()
        {
            int user = (int)Session["userId"];
            var jobseekerid = (from p in db.JobSeekers where p.UserId.UserId == user select p.Id).FirstOrDefault();
            var joboffer = (from p in db.Matches where p.JobSeekerId== jobseekerid select p.CompanyId).ToList();
            var jobofferInfo = (from p in db.JobOffers where joboffer.Contains(p.Id) select p).ToList();
            return View(jobofferInfo);

        }
        public ActionResult IndexC()
        {
            int user = (int)Session["userId"];
            var companyid = (from p in db.Companies where p.UserId.UserId == user select p.Id).FirstOrDefault();
            var companyoffer = (from p in db.JobOffers where p.Company.Id == companyid select p.Id);
            var jobseeker = (from p in db.Matches where companyoffer.Contains(p.CompanyId) select p.JobSeekerId).ToList();
            var jobSeekerinfo = (from p in db.JobSeekers where jobseeker.Contains(p.Id) select p).ToList();

            return View(jobSeekerinfo);

        }
    }
}