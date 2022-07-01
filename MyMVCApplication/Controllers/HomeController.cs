using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApplication.Controllers
{
    //To handle error and pass User to View Error.cshtml use [HandleError]
    /// </summary>
   
    public class HomeController : Controller
    {
        [HandleError]
        public ActionResult Index()
        {
            //TempData////////////////
            //TempData is used to transfer data from view to controller, controller to view,
            //or from one action method to another action method of the same or a different controller. 
            TempData["name"] = "Bill";

            //throw exception for demo
            //throw new Exception("This is unhandledException");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //TempData
            string name = "";
            if (TempData.ContainsKey("name"))
            {
                name = TempData["name"].ToString(); //return Bill
            }
            TempData.Keep("name"); // Marks the specified key in the TempData for retention.

            //TempData.Keep(); // Marks all keys in the TempData for retention
            return View();
        }

        //To handle error use this
       
        public ActionResult Contact()
        {
            //TempData
            //the following throws exception as TempData["name"] is null 
            //because we already accessed it in the About() action method
            //name = TempData["name"].ToString(); 

            string message = null;
            ViewBag.Message = "Your contact page.";
            //ViewBag.Message = message.Length;//// this will throw an exception

            return View();
        }

        //Or we can do this to handle error:
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            //Log the error!!

            //Redirect to action
            filterContext.Result = RedirectToAction("Error", "InternalError");

            // OR return specific view
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Error/InternalError.cshtml"
            };
            //base.OnException(filterContext);

        }

        //To render a partial view using the RenderAction() method,
        //first create an HttpGet action method and apply the ChildActionOnly attribute as shown below.
        [ChildActionOnly]
        public ActionResult Rendermenu()
        {
            return PartialView("_MenuBar");
        }

       
    }
}