using FormSubmission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Index(int a=0) {
        //public ActionResult Index(FormCollection f)
        //public ActionResult Index(string Uname,string Pass)
        public ActionResult Index(Login login)
        {
            //ViewBag.Msg = "Post Method";
            //ViewBag.Name = Request["Uname"];
            //ViewBag.Pass = Request["Pass"];

            //ViewBag.Name = f["Uname"];
            //ViewBag.Pass = f["Pass"];

            //ViewBag.Name = Uname;
            //ViewBag.Pass = Pass;
            return View(login);
        }

        public ActionResult About()
        {
            /*Student[] students = new Student[10];
            for (int i = 0; i < 10; i++) {
                students[i] = new Student();
                students[i].Name = "st " + (i + 1);
                students[i].Id = "st " + (i + 1);
                students[i].Cgpa = 3.45;

            }*/
            List<Student>  students = new List<Student>();
            for (int i = 1; i <= 10; i++) { 
                students.Add(new Student() 
                { 
                    Id="st"+i,Name="str"+1,Cgpa=3.45
                }
                );
            }


            return View(students);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}