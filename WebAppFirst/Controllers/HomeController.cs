using System.Linq;
using System.Web.Mvc;
using WebAppFirst.Models;

namespace WebAppFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (Session["Username"] == null)
                {
                    ViewBag.LoggedStatus = "Out";
                }
                else ViewBag.LoggedStatus = "In";
                return View();
            }

        }


        public ActionResult About()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (Session["Username"] == null)
                {
                    ViewBag.LoggedStatus = "Out";
                }
                else ViewBag.LoggedStatus = "In";
                ViewBag.Message = "Yhtiön perustietojen kuvailua";
                ViewBag.Herja = "Ole huolellinen, niin ei tule virhettä ";
                return View();
            }



        }

        public ActionResult Contact()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (Session["Username"] == null)
                {
                    ViewBag.LoggedStatus = "Out";
                }
                else ViewBag.LoggedStatus = "In";
                ViewBag.Message = "Yhteystietomme.";

                return View();
            }

        }

        public ActionResult Map()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (Session["Username"] == null)
                {
                    ViewBag.LoggedStatus = "Out";
                }
                else ViewBag.LoggedStatus = "In";
                ViewBag.Message = "Saapumisohje";

                return View();
            }


        }

        public ActionResult Login()
        {
            if (Session["Username"] == null)
            {
                ViewBag.LoggedStatus = "Out";
            }
            else ViewBag.LoggedStatus = "In";
            return View();

        }
        [HttpPost]
        public ActionResult Authorize(Logins LoginModel)
        {
            NorthwindOriginalEntities3 db = new NorthwindOriginalEntities3();
            //Haetaan käyttäjän/Loginin tiedot annetuilla tunnustiedoilla tietokannasta LINQ -kyselyllä
            var LoggedUser = db.Logins.SingleOrDefault(x => x.UserName == LoginModel.UserName && x.PassWord == LoginModel.PassWord);
            if (LoggedUser != null)
            {
                ViewBag.LoginMessage = "Successfull login";
                ViewBag.LoggedStatus = "In";
                Session["UserName"] = LoggedUser.UserName;
                return RedirectToAction("Index", "Home"); //Tässä määritellään mihin onnistunut kirjautuminen johtaa --> Home/Index
            }
            else
            {
                ViewBag.LoginMessage = "Login unsuccessfull";
                ViewBag.LoggedStatus = "Out";
                LoginModel.LoginErrorMessage = "Tuntematon käyttäjätunnus tai salasana.";
                return View("Login", LoginModel);
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            ViewBag.LoggedStatus = "Out";
            return RedirectToAction("Index", "Home"); //Uloskirjautumisen jälkeen pääsivulle
        }
    }
}