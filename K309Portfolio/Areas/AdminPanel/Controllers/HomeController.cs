using K309Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K309Portfolio.Areas.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        PortfolioDB db = new PortfolioDB();
        // GET: AdminPanel/Home
        public ActionResult Index()
        {
            if (Session["ActiveAdmin"] == null)
            {
                return RedirectToAction("Login", "AdminAccount");
            }
            return View();
        }

        
    }
}