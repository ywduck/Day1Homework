using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Day1Homework.Models.ViewModels;

namespace Day1Homework.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult MoneyList() {
            List<MoneyRecViewModel> listMoneyRec = new List<MoneyRecViewModel>();
            listMoneyRec.Add(new MoneyRecViewModel()
            {
                MoneyType = "支出",
                CreDate = DateTime.Now.ToString("yyyy/MM/dd"),
                Amount = 300
            });

            return View(listMoneyRec);
        }
    }
}