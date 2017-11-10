using NewsletterManager.Core.BE;
using NewsletterManager.Core.BLL;
using System;
using System.Web.Mvc;

namespace NewsletterManager.Controllers
{
    public class NewsletterController : Controller
    {
        public ActionResult Newsletter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Newsletter(Newsletter model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    NewsletterManagerBLL newsletterManager = new NewsletterManagerBLL();
                    newsletterManager.SaveNewsletter(model);
                    return RedirectToAction("NewsletterSignedup", new { emailAddress = model.EmailAddress });
                }
                catch(ArgumentException ae)
                {
                    ModelState.AddModelError((ae.ParamName ?? string.Empty), ae.Message.Split('\r')[0]);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Sorry, an error occurred while signing up the newsletter. Please try again.");
                }
            }
            return View();
        }

        public ActionResult NewsletterSignedup(string emailAddress)
        {
            ViewBag.EmailAddress = emailAddress;
            return View();
        }
    }
}