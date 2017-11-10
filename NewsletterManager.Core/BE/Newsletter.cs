using System;
using System.ComponentModel.DataAnnotations;

namespace NewsletterManager.Core.BE
{
    public class Newsletter
    {
        [Key]
        public int NewsletterId { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [StringLength(100, ErrorMessage ="Email address must be less than 100 characters")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please select how you heard about us")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select how you heard about us")]
        [Display(Name = "How Heard About Us")]
        public HeardAboutUsSource HowHeardAboutUs { get; set; }

        [Display(Name = "Reason")]
        [StringLength(250, ErrorMessage = "Reason must be less than 250 characters")]
        public string Reason { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }

    public enum HeardAboutUsSource
    {
        Advert = 1,

        [Display(Name = "Word of Mouth")]
        WordofMouth = 2,

        Other =3
    }
}
