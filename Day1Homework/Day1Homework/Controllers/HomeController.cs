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

        [ChildActionOnly]
        public ActionResult MoneyList() {
            List<MoneyRecViewModel> listMoneyRec = new List<MoneyRecViewModel>();
            listMoneyRec.Add(new MoneyRecViewModel()
            {
                Id = "1",
                MoneyType = "支出",
                CreDate = DateTime.Now.ToString("yyyy/MM/dd"),
                Amount = 300
            });
            listMoneyRec.Add(new MoneyRecViewModel()
            {
                Id = "2",
                MoneyType = "支出",
                CreDate = DateTime.Now.AddDays(1).ToString("yyyy/MM/dd"),
                Amount = 1600
            });
            listMoneyRec.Add(new MoneyRecViewModel()
            {
                Id = "3",
                MoneyType = "支出",
                CreDate = DateTime.Now.AddDays(2).ToString("yyyy/MM/dd"),
                Amount = 600
            });

            return View(listMoneyRec);
        }
    }
}