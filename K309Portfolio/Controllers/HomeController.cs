using K309Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K309Portfolio.Controllers
{
    public class HomeController : Controller
    {
        PortfolioDB db = new PortfolioDB();
        public ActionResult Index()
        {
            ViewBag.section1 = db.Section1.First();
            ViewBag.service = db.ServiceSections.OrderByDescending(x=>x.id).Take(3).ToList();
            ViewBag.portfolio = db.PortfolioSections.OrderBy(x=>x.id).ToList();
            ViewBag.about = db.AboutSections.OrderBy(x => x.id).ToList();
            return View();
        }
        //Where ,select,first,firstorDefault,

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult GetPortfolio(int? portId)
        {
            PortfolioSection selectedPort = db.PortfolioSections.Find(portId);
            ViewBag.portfolio = selectedPort;
            return PartialView("_PortfolioInfo");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}