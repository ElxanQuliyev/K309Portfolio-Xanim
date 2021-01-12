using K309Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K309Portfolio.Areas.AdminPanel.Controllers
{
    public class AdminAccountController : Controller
    {
        PortfolioDB db = new PortfolioDB();
        // GET: AdminPanel/AdminAccount
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            Admin selectedAdmin=db.Admins.FirstOrDefault(ad => ad.AdminEmail == admin.AdminEmail);
            if (selectedAdmin != null)
            {
                if (admin.AdminPassword == selectedAdmin.AdminPassword)
                {
                    Session["ActiveAdmin"] = selectedAdmin;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["ActiveAdmin"] = null;
            return RedirectToAction("Login","AdminAccount");
        }
    }
}