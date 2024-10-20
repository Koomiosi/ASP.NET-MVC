using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAppFirst.Models;

namespace WebAppFirst.Controllers
{
    public class ProductsController2 : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (Session["UserName"] == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                else ViewBag.LoggedStatus = "In";
                NorthwindOriginalEntities3 db = new NorthwindOriginalEntities3();
                List<Products> model = db.Products.ToList();
                db.Dispose();
                return View(model);
            }

        }

        public ActionResult Index2()
        {
            NorthwindOriginalEntities3 db = new NorthwindOriginalEntities3();
            List<Products> model = db.Products.ToList();
            db.Dispose();
            return View(model);
        }
    }
}