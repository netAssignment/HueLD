using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManager.Models;

namespace LibraryManager.Controllers
{
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/
        BookContext db = new BookContext();
        public ActionResult Account()
        {
            return View();
        }

        public ActionResult Book()
        {
            return View();
        }
        #region Categories
        public ActionResult Categories()
        {         
            return View(db.Categories.ToList());
        }
        [HttpPost]
        public ActionResult SaveCategory(string CategoriesName)
        {
            try
            {
                Category c = new Category();
                c.CategoriesName = CategoriesName;


                db.Categories.Add(c);
                //db.SaveChanges();
                return PartialView("~/Views/Partial/_SaveCategories.cshtml", db.Categories.ToList());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error.cshtml");
            }            
        }
        #endregion
        public ActionResult _PartialAddRecord()
        {
            return PartialView("~/Views/Partial/_PartialAddRecord.cshtml");
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
