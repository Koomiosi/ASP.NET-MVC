using System.Web.Mvc;

namespace WebAppFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Yhtiön perustietojen kuvailua";
            ViewBag.Herja = "Ole huolellinen, niin ei tule virhettä ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Yhteystietomme.";

            return View();
        }

        public ActionResult Map()
        {
            ViewBag.Message = "Saapumisohje";

            return View();
        }
    }
}