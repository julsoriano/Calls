using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calls.Models;
using System.Threading.Tasks;

namespace Calls.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /*
        public ActionResult Index()
        {
            try
            {
                Setting initSet = db.Setting.Single();
                return RedirectToAction("Index", "Call", new { set = initSet.InitialScreen });
            }
            catch (System.InvalidOperationException)
            {
                return RedirectToAction("Index", "Call", new { set = 2 });
            }
        }
        */
        [AllowAnonymous]
        public ActionResult Index()
        {     
            return RedirectToAction("Index", "Call", new { sortOrder = "Name" });
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}