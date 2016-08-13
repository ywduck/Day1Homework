using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Day1Homework.Models.ViewModels;
using Day1Homework.Service;

namespace Day1Homework.Controllers
{
    public class HomeController : Controller
    {
        private MoneryService _MoneryService = new MoneryService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult MoneyList() {
            List<MoneyRecViewModel> listMoneyRec = _MoneryService.GetAccountBook();
            return View(listMoneyRec);
        }
    }
}