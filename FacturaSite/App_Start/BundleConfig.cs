using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FacturaSite
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254726
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Order of CSS or Js
            // 1. JQuery
            // 2. Bootstrap

            #region JS / SCRIPT

            bundles.Add(new ScriptBundle("~/bundles/jQuery").Include(
                "~/Scripts/jquery-{version}.js"
                , "~/Scripts/jquery-ui-{version}.js"
                //, "~/Scripts/jquery-2.1.3.intellisense.js"
                , "~/Scripts/bootstrap.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/dropzonescripts").Include(
                "~/Scripts/dropzone/dropzone.js"));

            #endregion

            #region CSS / STYLE

            bundles.Add(new StyleBundle("~/bundles/BootstrapCss").Include(
                "~/Content/bootstrap.css"
                , "~/Content/bootstrap-theme.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/jQueryUICss").Include(
                 "~/Content/themes/base/theme.css"
                , "~/Content/themes/base/datepicker.css"
                ));

            bundles.Add(new StyleBundle("~/Content/dropzonescss").Include(
                "~/Scripts/dropzone/basic.css",
                "~/Scripts/dropzone/dropzone.css"));

            #endregion

            // Enable bundle optimization.
            BundleTable.EnableOptimizations = true;
        }
    }
}