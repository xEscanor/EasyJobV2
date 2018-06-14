﻿using System;
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
    public class AddJobSeekersController : Controller
    {
        private EasyJobContext db = new EasyJobContext();

         public ActionResult Index()
        {
            return View(db.JobSeekers.ToList());
        }

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
        public ActionResult Create([Bind(Include = "Id,Email,Username,LastName,FirstName,BirthDay,Age,Diploma,Experience,Gender")] JobSeeker jobSeeker)
        {
            JobSeeker jobseeker = (from c in db.JobSeekers
                                  where c.Id == Convert.ToInt32(Session["userID"])
                                  select c).FirstOrDefault();
            Console.WriteLine(jobseeker.Id.ToString());
            //if (ModelState.IsValid)
            //{
            //db.JobSeekers.Add(jobSeeker);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            // }
            Console.WriteLine("oui");
            return View(jobSeeker);
        }

 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Username,LastName,FirstName,BirthDay,Age,Diploma,Experience,Gender")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSeeker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobSeeker);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            db.JobSeekers.Remove(jobSeeker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
