using NewsletterManager.Core.BE;
using NewsletterManager.Core.DAL;
using System;
using System.Linq;

namespace NewsletterManager.Core.BLL
{
    public class NewsletterManagerBLL
    {
        private INewsletterDB _newsletterDB;

        /// <summary>
        /// Empty constructor
        /// Not creating _newsletterDB here to hide dbcontext from the controller methods
        /// </summary>
        public NewsletterManagerBLL() { }

        /// <summary>
        /// Constructor to inject dbcontext object
        /// Can use to inject mock data from the unit test module
        /// </summary>
        /// <param name="NewsletterDB"></param>
        public NewsletterManagerBLL(INewsletterDB NewsletterDB)
        {
            _newsletterDB = NewsletterDB;
        }

        /// <summary>
        /// Saving sign up details for the newsletter
        /// </summary>
        /// <param name="newsletter">Details to sign up</param>
        public void SaveNewsletter(Newsletter newsletter)
        {
            if (_newsletterDB == null)
                _newsletterDB = new NewsletterDB();

            ArgumentException ae = ValidateNewletter(newsletter);
            if (ae != null)
                throw ae;

            newsletter.CreatedOn = DateTime.Now;
            newsletter.CreatedBy = "NewletterManager";

            _newsletterDB.Newsletters.Add(newsletter);
            (_newsletterDB as NewsletterDB).SaveChanges();
        }

        private ArgumentException ValidateNewletter(Newsletter newsletter)
        {
            ArgumentException ae = null;

            if (newsletter == null)
                ae = new ArgumentException("Invalid newsletter.", string.Empty);

            else if (string.IsNullOrWhiteSpace(newsletter.EmailAddress))
                ae = new ArgumentException("Invalid email address.", "EmailAddress");

            else if (_newsletterDB.Newsletters.Any(n => n.EmailAddress == newsletter.EmailAddress))
                ae = new ArgumentException("Email address already signed up.", "EmailAddress");

            else if(!Enum.IsDefined(typeof(HeardAboutUsSource), newsletter.HowHeardAboutUs))
                ae = new ArgumentException("Invalid value for how heard about us.", "HowHeardAboutUs");

            return ae;
        }

    }
}
