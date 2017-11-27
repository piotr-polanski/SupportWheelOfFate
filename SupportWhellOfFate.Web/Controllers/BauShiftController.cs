using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupportWheelOfFate.Domain;

namespace SupportWhellOfFate.Web.Controllers
{
    public class BauShiftController : Controller
    {
        private IWheelOfFate _wheelOfFate;
        public BauShiftController(IWheelOfFate wheelOfFate)
        {
            _wheelOfFate = wheelOfFate;
        }

        // GET: BauShift
        public ActionResult Index()
        {
            var bauShift = _wheelOfFate.SelectTodaysBauShift();
            return View(bauShift);
        }
    }
}
