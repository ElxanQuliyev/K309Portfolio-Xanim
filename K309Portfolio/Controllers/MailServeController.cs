using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace K309Portfolio.Controllers
{
    public class MailServeController : Controller
    {
        // GET: MailServe
        [HttpPost]
        public ActionResult SendMail(string name,string phone,string email,string message)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["Email"].ToString());
            mail.From = new MailAddress(email);
            mail.Subject = "Müraciət";
            string Body = string.Format($"Ad:{name} ,\nPhone:{phone},\nEmail:{email},\nMessage: {message}");
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(
                ConfigurationManager.AppSettings["Email"].ToString(),
                ConfigurationManager.AppSettings["Password"].ToString()
             ); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return RedirectToAction("Index","Home");
        }
    }
}