using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManager.Models;

namespace LibraryManager.Controllers
{
    public class CategoriesController : Controller
    {
        BookContext db = new BookContext();
        public ViewResult ChildrenBooks()
        {
            return View();
        }
        public ViewResult BusinessBooks()
        {
            return View();
        }
        public ViewResult LiteratureBooks()
        {
            return View();
        }
        public ViewResult MusicBooks()
        {
            return View();
        }
        public ViewResult TechnologyBooks()
        {
            return View();
        }

        public PartialViewResult LoadCategories()
        {
            try
            {
                List<Category> c = db.Categories.ToList();
                return PartialView(c);
            }
            catch
            {
                ViewBag.Error = "Cannot load Category";
                return PartialView("/Views/Partial/_ErrorPage.cshtml");
            }
           
        }

    }
}
