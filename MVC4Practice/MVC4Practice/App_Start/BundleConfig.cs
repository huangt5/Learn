using System.Web;
using System.Web.Optimization;

namespace MVC4Practice
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/i18n/jquery.ui.datepicker-zh-CN.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css",
                        "~/Content/jquery.jqGrid/ui.jqgrid.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/themes/redmond/css").Include(
                        "~/Content/themes/redmond/jquery-ui-1.9.2.redmond.css"));

            bundles.Add(new ScriptBundle("~/bundles/mvc4practice/global").Include(
                "~/Scripts/MVC4Practice.Global/Helpers.js"));

            bundles.Add(new ScriptBundle("~/bundles/mysite").Include(
                "~/Scripts/MySite.js"));

            bundles.Add(new ScriptBundle("~/bundles/console").Include(
                "~/Scripts/MVC4Practice.UI/Console.js"));

            bundles.Add(new ScriptBundle("~/bundles/mvc4practice/editform").Include(
                "~/Scripts/MVC4Practice.UI/FormGrid.js",
                "~/Scripts/jquery.jqGrid.js"));

            bundles.Add(new ScriptBundle("~/bundles/mvc4practice/listform").Include(
                "~/Scripts/MVC4Practice.UI/FormGrid.js",
                "~/Scripts/jquery.jqGrid.js"));
        }
    }
}