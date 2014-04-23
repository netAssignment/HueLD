using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManager.Models;

namespace LibraryManager.Controllers
{
    public class ManagerBookController : Controller
    {
        private BookContext db = new BookContext();

        //
        // GET: /ManagerBook/

        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Categories).Where(p=>p.IsDelete==false);
            return View(books.ToList());
        }

        //
        // GET: /ManagerBook/Details/5

        public ActionResult Details(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /ManagerBook/Create

        public ActionResult Create()
        {
            ViewBag.CategoriesId = new SelectList(db.Categories, "CategoriesId", "CategoriesName");
            return View();
        }

        //
        // POST: /ManagerBook/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriesId = new SelectList(db.Categories, "CategoriesId", "CategoriesName", book.CategoriesId);
            return View(book);
        }

        //
        // GET: /ManagerBook/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriesId = new SelectList(db.Categories, "CategoriesId", "CategoriesName", book.CategoriesId);
            return View(book);
        }

        //
        // POST: /ManagerBook/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriesId = new SelectList(db.Categories, "CategoriesId", "CategoriesName", book.CategoriesId);
            return View(book);
        }

        //
        // GET: /ManagerBook/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /ManagerBook/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            book.IsDelete = true;
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}