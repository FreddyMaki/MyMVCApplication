using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCApplication.Models;

namespace MyMVCApplication.Controllers
{
    public class LinqTrainingController : Controller
    {
        // GET: LinqTraining
        public ActionResult LinqIndex()
        {
            //-----PASS DATA FROM VIEW TO CONTROLLER:------
            //1 ********Method traditionnal*************************
            //Use:
            var valueFromFront = Request["inputName"];//origines is name of Html input or button or anything

            //Use FormCollection on parameter of method
            //ActionResult GetStatistique(FormCollection form);
            //to get value do:
            //form['origines'], form['categories']

            //2 *******Methode argument inside of controller method:*******
            //ActionResult GetStatistique(string origines, string categories)

            //3 *******Methode argument model inside controller method*******
            //ON CONTROLLER
            //ActionResult GetStatistique(StatMarketingModel myModel);
            //ON HTML example:
            //@Html.EditorFor(model => model.origines)


            //-------PASS DATA FROM CONTROLLER TO VIEW-------
            //But instead we can use ViewBag or ViewData too but not recommanded for performance:
            ViewBag.example = "Passing data with ViewBag"; //and call it on html like this: @ViewBag.exapmple to get value
            //We need to create a model before passing it to the view like a parameter
            //Example:
            //StatMarketingModel myModel = new StatMarketingModel() { Origine = "Value from controller", Categorie = "Tarte au pomme" };
            //return View(myModel);// We will pass values to the front with myModel by setting it as value on a parameter


            Student student = new Student() { StudentId = 1, StudentName = "Coco", Age = 15, isNewlyEnrolled = true, Password = "11111" };
            //return View("LinqIndex");
            return View("LinqIndex", student);//This will pass student model to the front
        }


        public ActionResult Accepter(Student student)
		{
            var valueFromFront = student.Age;
            return Content("Coucou Florin");
		}

        public ActionResult Checked()
        {
            //return View("LinqIndex");
            return Content("Coucou");
        }
    }
}