using System.Web.Mvc;
using SupportWheelOfFate.Domain;
using SupportWheelOfFate.Domain.Abstract;

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