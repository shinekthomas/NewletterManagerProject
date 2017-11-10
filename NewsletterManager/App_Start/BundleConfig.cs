using System.Web.Optimization;

namespace NewsletterManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

#if DEBUG
            Bundle jQueryBundle = new ScriptBundle("~/jQuery").Include("~/Scripts/jQuery/*.js");
#else
            Bundle jQueryBundle = new ScriptBundle("~/jQuery").Include("~/Scripts/jQuery/*.min.js");
            jQueryBundle.Transforms.Clear();
#endif
            bundles.Add(jQueryBundle);

            bundles.Add(new StyleBundle("~/SiteStyles").Include("~/Content/Site.css"));
        }
    }
}
