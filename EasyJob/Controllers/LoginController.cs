using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyJob.Models;

namespace EasyJob.Controllers
{
    public class LoginController : Controller
    {
        private EasyJobContext db = new EasyJobContext();

        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User userModel)
        {
            var BDD = db.Set<User>();
            var userDetails = BDD.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
            if (userDetails== null)
            {
                userModel.LoginErrorMessage = " Wrong username or Password.";
                return View("Index", userModel);
            }
            else
            {


                //test pour faire des updates
                var result = BDD.SingleOrDefault(b => b.Email == "test");
                if (result != null)
                {
                    result.Email = "test1";
                    db.SaveChanges();
                }
                //fin du test

                Session["userId"] = userDetails.UserId;
                this.Session["userFC"] = userDetails.FirstConnexion;
                Session["company"] = userDetails.IsCompany;

               if (BDD.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault().IsCompany)
                    return RedirectToAction("IndexC", "Home");
                else
                {
                    return RedirectToAction("IndexJS", "Home");
                }
            }
           
        }

        public ActionResult LogOut()
        {
            int userID = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}