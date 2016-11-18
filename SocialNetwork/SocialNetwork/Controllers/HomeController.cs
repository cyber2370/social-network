using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}