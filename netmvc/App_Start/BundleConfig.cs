using System.Web;
using System.Web.Optimization;

namespace netmvc
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/pignosecalendar").Include(
                      "~/Content/styles/plugins/pg-calendar/css/pignose.calendar.min.cs"));

            bundles.Add(new StyleBundle("~/Content/chartist").Include(
                      "~/Content/styles/plugins/chartist/css/chartist.min.css",
                      "~/Content/styles/plugins/chartist-plugin-tooltips/css/chartist-plugin-tooltip.css"));

            bundles.Add(new StyleBundle("~/Content/customcss").Include(
                      "~/Content/styles/css/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/templatescript").Include(
                        "~/Content/styles/plugins/common/common.min.js",
                        "~/Content/styles/js/custom.min.js",
                        "~/Content/styles/js/settings.js",
                        "~/Content/styles/js/gleek.js",
                        "~/Content/styles/js/styleSwitcher.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                        "~/Content/styles/plugins/chart.js/Chart.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/circleprogress").Include(
                        "~/Content/styles/plugins/circle-progress/circle-progress.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datamap").Include(
                        "~/Content/styles/plugins/d3v3/index.js",
                        "~/Content/styles/plugins/topojson/topojson.min.js",
                        "~/Content/styles/plugins/datamaps/datamaps.world.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/morrisjs").Include(
                      "~/Content/styles/plugins/raphael/raphael.min.js",
                      "~/Content/styles/plugins/morris/morris.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/pignosecalendarjs").Include(
                      "~/Content/styles/plugins/moment/moment.min.js",
                      "~/Content/styles/plugins/pg-calendar/js/pignose.calendar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartistjs").Include(
                      "~/Content/styles/plugins/chartist/js/chartist.min.js",
                      "~/Content/styles/plugins/chartist-plugin-tooltips/js/chartist-plugin-tooltip.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboardjs").Include(
                      "~/Content/styles/js/dashboard/dashboard-1.js"));

            bundles.Add(new StyleBundle("~/Content/datatablecss").Include(
                       "~/Content/styles/plugins/tables/css/datatable/dataTables.bootstrap4.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatablescript").Include(
                        "~/Content/styles/plugins/tables/js/jquery.dataTables.min.js",
                        "~/Content/styles/plugins/tables/js/datatable/dataTables.bootstrap4.min.js",
                        "~/Content/styles/plugins/tables/js/datatable-init/datatable-basic.min.js"
                        ));
            

        }
    }
}
