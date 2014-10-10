using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using witBondWatch.Web.Helpers;

namespace witBondWatch.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Loan()
        {
          return View();
        }
        

        public ActionResult About()
        {
          return View();
        }

        public JsonResult getTheBond(string bondName)
        {
          var model = ScreenScraperBondHelper.GetSpecificBond(bondName);
          return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getTheBonds()
        {
          var model = ScreenScraperBondHelper.GetBonds();
          return Json(model,JsonRequestBehavior.AllowGet);
        }

    }
}
