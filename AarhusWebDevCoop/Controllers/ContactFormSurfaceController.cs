using AarhusWebDevCoop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace AarhusWebDevCoop.Controllers
{
    public class ContactFormSurfaceController : SurfaceController    {
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            ActionResult res = CurrentUmbracoPage();
            if (ModelState.IsValid)
            {
                bool ok = false;
                try
                {
                    MailMessage message = new MailMessage();
                    message.To.Add("ceciliavejle@outlook.dk");
                    message.Subject = model.Subject;
                    message.From = new MailAddress(model.Email, model.Name);
                    message.Body = model.Message;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.EnableSsl = true;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential("ceciliasoerensen92@gmail.com", "sommerfugl!!");
                        smtp.EnableSsl = true;
                        // send mail
                        smtp.Send(message);
                    }
                    ok = true;

                }
                catch (Exception ex)
                {

                }

                //Laver indhold
                IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "message");

                comment.SetValue("messageName", model.Name);
                comment.SetValue("email", model.Email);
                comment.SetValue("subject", model.Subject);
                comment.SetValue("messageContent", model.Message);

                //Gemmer indhold, men publicer ikke
                Services.ContentService.Save(comment);

                //Gemmer og publicer indhold
                //Services.ContentService.(comment);

                TempData["success"] = ok;
                res =  RedirectToCurrentUmbracoPage();
            }


            return res;
        }
    }
}