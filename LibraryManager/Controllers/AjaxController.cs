using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using LibraryManager.Models;
namespace LibraryManager.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/

        public ActionResult Index()
        {
            
            return View();
        }

        public string index1(string page)
        {
            string result = "Không tồn tại tab này";
            switch (page)
            {
                case "1": result = "Một nè"; break;
                case "2": result = "Hai nè"; break;
                case "3": result = "Ba nè"; break;
                case "4": result = "Bốn nè"; break;
            }
            return result;
        }
        [HttpPost]
        public ActionResult test(string dealerID)
        {
            return Content("It works");
        }

        #region Grid jquerry
        public ActionResult MyTest()
        {
            return View();
        }

        
        #endregion
    }
}

