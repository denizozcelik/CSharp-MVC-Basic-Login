using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthentication.Controllers
{
    using Models;
    using MVCAuthentication.AuthenticationClass;
    using SingletonPattern;

    [EmployeeAuthentication]
    public class ProductController : Controller
    {
        NorthwindEntities db = DBTool.DBInstance;

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}