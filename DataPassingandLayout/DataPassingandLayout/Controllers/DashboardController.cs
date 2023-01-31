using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataPassingandLayout.Controllers
{
    public class DashboardController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            return View();
        }
        public ActionResult MyProfile() {
            //
            //
            //
            //
            ViewBag.Title = "Profile";
            ViewBag.Name = "Sabbir";
            ViewBag.Course = "Adv. .Net";
            ViewBag.Section = "A";
            ViewBag.Students = new string[] { "Shifat","Tahmid","Fahim","Israt","Nazia","Fatima"};
            return View();
        }
        public ActionResult Settings() {
            ViewBag.Title = "Settings";
            return View();
        }
        public ActionResult Logout() {
            return View();
        }
    }
}