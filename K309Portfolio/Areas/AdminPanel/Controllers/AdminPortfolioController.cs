using K309Portfolio.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace K309Portfolio.Areas.AdminPanel.Controllers
{
    [AdminFilter]
    public class AdminPortfolioController : Controller
    {
        PortfolioDB db = new PortfolioDB();
        // GET: AdminPanel/AdminPortfolio
        public ActionResult Index()
        {
            return View(db.PortfolioSections.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();
            PortfolioSection selectedPort= db.PortfolioSections.FirstOrDefault(p => p.id == id);
            if (selectedPort == null)  return HttpNotFound();
            return View(selectedPort);
        }
        public ActionResult Create()
        {
            ViewBag.categories = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(PortfolioSection portfolioSection,HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                WebImage img = new WebImage(Photo.InputStream);
                FileInfo file = new FileInfo(Photo.FileName);
                string imgUrl = Guid.NewGuid().ToString() + file.Extension;
                img.Save("~/Images/" + imgUrl);
                portfolioSection.imageUrl = "/Images/" + imgUrl;
            }
            ViewBag.categories = db.Categories.ToList();
            db.PortfolioSections.Add(portfolioSection);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? portId)
        {
            PortfolioSection port = db.PortfolioSections.Find(portId);
            db.PortfolioSections.Remove(port);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();
            PortfolioSection selectedPort = db.PortfolioSections.FirstOrDefault(p => p.id == id);
            ViewBag.categories = db.Categories.ToList();
            if (selectedPort == null) return HttpNotFound();
            return View(selectedPort);
        }

        [HttpPost]
        public ActionResult Edit(int? id,PortfolioSection portfolioSection,HttpPostedFileBase Photo)
        {
            if (id == null) return HttpNotFound();
            PortfolioSection selectedPort = db.PortfolioSections.First(x => x.id == id);
            if (Photo != null)
            {
                if (System.IO.File.Exists(Server.MapPath(selectedPort.imageUrl)))
                {
                    System.IO.File.Delete(Server.MapPath(selectedPort.imageUrl));
                }
                WebImage img = new WebImage(Photo.InputStream);
                FileInfo file = new FileInfo(Photo.FileName);
                string imgUrl = Guid.NewGuid().ToString() + file.Extension;
                img.Save("~/Images/" + imgUrl);
                selectedPort.imageUrl = "/Images/" + imgUrl;
            }
            selectedPort.header = portfolioSection.header;
            selectedPort.deccription = portfolioSection.deccription;
            selectedPort.publishDate=portfolioSection.publishDate;
            selectedPort.categoryId = portfolioSection.categoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}