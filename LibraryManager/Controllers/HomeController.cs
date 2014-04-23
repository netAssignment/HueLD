using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult image()
        {
            return View();
        }

        [HttpPost]
        public ActionResult imagePost(HttpPostedFileBase NAMEbtnUpload)
        {
            if (NAMEbtnUpload.ContentLength > 0)
            {
                var fileName = System.IO.Path.GetFileName(NAMEbtnUpload.FileName);
                var path = System.IO.Path.Combine(Server.MapPath("~/App_Data"), fileName);
                NAMEbtnUpload.SaveAs(path);
            }

            return RedirectToAction("image");
        }
    }
}
