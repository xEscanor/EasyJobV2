using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyJob.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace EasyJob.Controllers
{
    public class UserController : Controller
    {
        private EasyJobContext db = new EasyJobContext();

        [HttpGet]
        public ActionResult AddOrEditC(int id=0)
        {
            User userModel = new User();

            return View(userModel);
        }

        [HttpGet]
        public ActionResult AddOrEditJS(int id = 0)
        {
            User userModel = new User();

            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEditC(User userModel)
        {
            var BDD = db.Set<User>();

            if (BDD.Any(x => x.Email == userModel.Email))
            {
                ViewBag.DuplicateMessage = "Username already exist.";
                return View("AddOrEdit", userModel);
            }

            BDD.Add(userModel);
            db.SaveChanges();

            ViewBag.SuccesMessage = "Registration successful";
            return View(viewName: "AddOrEditC", model: new User());
        }

        public ActionResult AddOrEditJS(User userModel)
        {
            var BDD = db.Set<User>();

            if (BDD.Any(x => x.Email == userModel.Email))
            {
                ViewBag.DuplicateMessage = "Username already exist.";
                return View("AddOrEdit", userModel);
            }
            else
            {
                BDD.Add(userModel);
                db.SaveChanges();

                ViewBag.SuccesMessage = "Registration successful";
                return View(viewName: "AddOrEditJS", model: new User());
            }
        }
    }
}