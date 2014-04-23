using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManager.Models;

namespace LibraryManager.Controllers
{
    public class MyHomeController : Controller
    {
        //
        // GET: /Home/
        BookContext db=new BookContext();
        public ActionResult Index()
        {
            return View(db.Books.Where(p => p.IsDelete == false).OrderByDescending(date => date.DateUpdate).ToList());
        }
        public ViewResult About()
        {
            return View();
        }
    }
}
