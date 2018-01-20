using System.Web.Optimization;

namespace Virgil
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
            //          "~/Scripts/tinymce/tinymce.js"));

            bundles.Add(new ScriptBundle("~/bundles/qtip").Include(
                      "~/Scripts/qTip/jquery.qtip.js"));

            bundles.Add(new ScriptBundle("~/bundles/spectrum").Include(
                      "~/Scripts/spectrum.js"));

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                      "~/Scripts/chosen.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/virgil").Include(
                      "~/Scripts/Virgil.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Scripts/tinymce/skins/lightgray/skin.min.css",
                      "~/Scripts/qTip/jquery.qtip.css",
                      "~/Content/spectrum.css",
                      "~/Content/bootstrap.css",
                      "~/Content/chosen.css",
                      "~/Content/site.css"));
        }
    }
}
