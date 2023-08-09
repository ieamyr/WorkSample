using System.Web;
using System.Web.Optimization;

namespace MyWork
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js","~/Scripts/popper.min.js","~/Scripts/bootstrap.min.js","~/Scripts/select2.min.js"
                        ,"~/Scripts/slick.js","~/Scripts/moment.min.js","~/Scripts/daterangepicker.js","~/Scripts/summernote.min.js"
                        ,"~/Scripts/metisMenu.min.js","~/Scripts/custom.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/styles.css"));
        }
    }
}
