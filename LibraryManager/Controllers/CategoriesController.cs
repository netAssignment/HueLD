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

        //Load category tu database len website
        public ActionResult _LoadCategoryPartial()
        {
            var categories=db.Categories.Where(p=>p.IsDelete==false).ToList();
            return PartialView(categories);
        }

        //Action nay se chiu trach nhiem ung voi link category nao thi se lay ra nhung
        //cuon sach thuoc category do
        public ActionResult CategoryLink(int? id)
        {
            if (id.HasValue)
            {
                ViewBag.TitleCategories = db.Categories.FirstOrDefault(p => p.CategoriesId == id).CategoriesName;
                if (id == 1)
                {
                    return View(db.Books.Where(p => p.IsDelete == false).OrderByDescending(date => date.DateUpdate).ToList());
                }

                return View(db.Books.Where(p => p.IsDelete == false).Where(p => p.CategoriesId == id).ToList());
            }
            return View();
        }

        public string GetAuthorByBookID(int bookID)
        {
            var kk = (from p in db.TakePartIns
                     from q in db.Authors
                     where p.AuthorId == q.AuthorId && p.BookId == bookID
                     select new { q.AuthorName }).ToList();
            System.Text.StringBuilder str =new System.Text.StringBuilder();
            foreach (var item in kk)
            {
                str.Append(item.AuthorName.ToString());
                str.Append(", ");
            }
            if(str.Length>2)str.Remove(str.Length - 2, 2);
            return str.ToString();
        }
    }
}
