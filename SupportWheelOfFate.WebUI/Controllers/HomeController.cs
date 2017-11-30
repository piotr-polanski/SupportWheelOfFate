using System.Web.Mvc;
using SupportWheelOfFate.Domain;

namespace SupportWheelOfFate.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWheelOfFate _wheelOfFate;

        public HomeController(IWheelOfFate wheelOfFate)
        {
            _wheelOfFate = wheelOfFate;
        }
        public ActionResult Index()
        {
            var bauShift = _wheelOfFate.SelectTodaysBauShift();
            return View(bauShift);
        }
    }
}