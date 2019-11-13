using MVCAuthentication.Models;
using MVCAuthentication.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthentication.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = DBTool.DBInstance;
        // GET: Home



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Employee item)
        {
            if (db.Employees.Any(e => e.FirstName == item.FirstName && e.LastName == item.LastName))
            {

                Employee girisYapan = db.Employees.Where(x => x.FirstName == item.FirstName && x.LastName == item.LastName).First();

                Session["oturum"] = girisYapan;

                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Message = "Böyle bir kullanıcı bulunamadı";
                return View();
            }

        }


        public ActionResult Index()
        {
            return View();
        }




    }
}