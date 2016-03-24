using System.Web;
using System.Web.Optimization;

namespace Crazy.Cards.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Content/scripts").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery.js", 
                      "~/Scripts/cbpAnimatedHeader.js",
                      "~/Scripts/freelancer.js",
                      "~/Scripts/classie.js",
                      "~/Scripts/angular.js"


                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/freelancer.css",
                      "~/font-awesome/css/font-awesome.min.css"));
        }
    }
}
