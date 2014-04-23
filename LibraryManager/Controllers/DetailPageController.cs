using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManager.Controllers
{
    public class DetailPageController : Controller
    {
        //
        // GET: /DetailPage/

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
        
    }
}
