using System.Web;
using System.Web.Optimization;

namespace TesteNET
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Scripts").Include(
                      "~/Scripts/jquery.js",
                      "~/assets/jquery-ui/jquery-ui-1.10.1.custom.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.dcjqaccordion.2.7.js",
                      "~/Scripts/jquery.scrollTo.min.js",
                      "~/Scripts/slidebars.min.js",
                      "~/Scripts/jquery.nicescroll.js",
                      "~/Scripts/respond.min.js",
                      "~/assets/fancybox/source/jquery.fancybox.js",
                      "~/assets/toastr-master/toastr.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-reset.css",
                      "~/assets/jquery-ui/jquery-ui-1.10.1.custom.min.css",
                      "~/assets/font-awesome/css/font-awesome.css",
                      "~/assets/fancybox/source/jquery.fancybox.css",
                      "~/assets/toastr-master/toastr.css",
                      "~/assets/morris.js-0.4.3/morris.css"));
        }
    }
}
