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

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery.js"
                      ));
            bundles.Add(new ScriptBundle("~/Scripts/freelancer")
                .Include(
                "~/Scripts/classie.js",
                  "~/Scripts/cbpAnimatedHeader.js",
                      "~/Scripts/freelancer.js"
                ));
            bundles.Add(new ScriptBundle("~/Scripts/Angular")
                .Include(
                "~/Scripts/angular.js",
                "~/Scripts/AngularUI/ui-router.js",
                "~/Angular/Module/loading-bar.min.js",
                "~/Angular/Module/crazyCards.js",
                "~/Angular/Controllers/cardsController.js",
                "~/Angular/Controllers/offersController.js"

                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/freelancer.css",
                      "~/Content/loading-bar.min.css",
                      "~/font-awesome/css/font-awesome.min.css"));
        }
    }
}
