using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManager.Models;
using System.Text;
using LibraryManager.ViewModel;
using LibraryManager.MyClass;
using CaptchaMvc.Attributes;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc.Interface;

namespace LibraryManager.Controllers
{
    public class DetailPageController : Controller
    {
        //
        // GET: /DetailPage/
        BookContext db = new BookContext();
        JsonReadWrite<Model> json = new JsonReadWrite<Model>();
        public ActionResult Gruffalo()
        {
            return View();
        }

        public ActionResult OldMacdonaldHadZoo()
        {
            return View();
        }

        public ActionResult BooksSignedByMusicians()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadDetailPage(int bookId)
        {
            Book b=db.Books.FirstOrDefault(book => book.BookId == bookId);
            StringBuilder str = new StringBuilder();
            string fileName = bookId.ToString() + ".txt";//Lay ten san pham la ten file
            string path = Server.MapPath("~/Json File/ListComment");
            List<Model> list12 = json.JsonFileToObject(bookId.ToString(), path, 10);

            Model model = new Model();
            list12.Reverse();//Dao nguoc list de y kien moi nhat duoc doc dau tien
            model.ListComment = list12;

            ViewBag.sss = model;
            ViewBag.NgaMap = b;
            ViewBag.aaa = str;

            return View(b); 
        }

        [HttpPost, CaptchaVerify("Captcha is not valid")]
        [ValidateAntiForgeryToken]
        public ActionResult LoadDetailPage(string bookID, Model model)
        {
            try
            {
                string fileName = bookID + ".txt";//Lay ten san pham la ten file
                string path = Server.MapPath("~/Json File/ListComment");
                List<Model> list12 = json.JsonFileToObject(bookID, path, 10);
                int intBookID=int.Parse(bookID);
                Book sp = db.Books.FirstOrDefault(p => p.BookId == intBookID);
                StringBuilder str = new StringBuilder();
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                ViewBag.NgaMap = sp;

                ViewBag.aaa = str;

                if (ModelState.IsValid)
                {
                    //model.Content = model.Content.ElementAtOrDefault(0).ToString();
                    json.ObjectToJsonFile(bookID, new List<Model>() { model }, path);

                    list12.Add(model);
                    list12.Reverse();
                    model.ListComment = list12; string a = "";
                    if (Request.IsAjaxRequest())
                    {
                        //Book sanpham = db.Books.Single(p => p.BookId.ToString() == bookID);
                        //int danhgia = 0;
                        //if (sanpham.LuotDanhGia != null && int.TryParse(model.DanhGia, out danhgia))
                        //{
                        //    sanpham.LuotDanhGia++;
                        //    // sanpham.DanhGia = HienThiDanhGia(sanPhamId)/sanpham.LuotDanhGia+sanpham.DanhGia;   
                        //    sanpham.DanhGia = danhgia / sanpham.LuotDanhGia + sanpham.DanhGia / sanpham.LuotDanhGia;
                        //    if (sanpham.KhuyenMai == null)
                        //        sanpham.KhuyenMai = 0;
                        //    db.SaveChanges();
                        //}
                        //else
                        //{
                        //    try
                        //    {
                        //        sanpham.LuotDanhGia = 1;
                        //        sanpham.DanhGia = int.Parse(model.DanhGia);
                        //        if (sanpham.KhuyenMai == null)
                        //            sanpham.KhuyenMai = 0;
                        //        db.SaveChanges();
                        //    }
                        //    catch (System.Data.Entity.Validation.DbEntityValidationException e)
                        //    {
                        //        foreach (var eve in e.EntityValidationErrors)
                        //        {
                        //            a += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        //                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        //            foreach (var ve in eve.ValidationErrors)
                        //            {
                        //                a += string.Format("- Property: \"{0}\", Error: \"{1}\"",
                        //                    ve.PropertyName, ve.ErrorMessage);
                        //            }
                        //        }
                        //        // throw;
                        //    }
                        //}

                        return PartialView("~/Views/Partial/_PartialViewComment.cshtml", model);
                    }
                    return View(model);
                }
                list12.Reverse();
                model.ListComment = list12;
                TempData["ErrorMessage"] = "Error: Captcha is not valid";
                if (Request.IsAjaxRequest())
                    return PartialView("~/Views/Partial/_PartialViewComment.cshtml", model);
                ViewBag.sss = model;
                return View(sp);
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
    }
}
