using System.Web;
using System.Web.Optimization;

namespace TemplatePOC.Web
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/tools").Include(
                    "~/Scripts/vendors/jquery/jquery.js",
                    "~/Scripts/vendors/jquery-validation/jquery.validate.js",
                    "~/Scripts/vendors/jquery-validation/additional-methods.js",
                    "~/Scripts/vendors/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js",
                    "~/Scripts/vendors/bootstrap/bootstrap.js",
                    "~/Scripts/vendors/respond/respond.src.js",
                    "~/Scripts/vendors/respond/respond.matchmedia.addListener.src.js",
                    "~/Scripts/vendors/angular/angular.js",
                    "~/Scripts/vendors/angular-ui-route/angular-ui-router.js",
                    "~/Scripts/vendors/angular-resource/angular-resource.js",
                    "~/Scripts/vendors/angular-ui-bootstrap/ui-bootstrap.js",
                    "~/Scripts/vendors/angular-ui-bootstrap/ui-bootstrap-tpls.js",
                    "~/Scripts/vendors/angular-validation/angular-validation.js",
                    "~/Scripts/vendors/angular-validation/angular-validation-rule.js",
                    "~/Scripts/vendors/csslint/node-parserlib.js",
                    "~/Scripts/vendors/csslint/csslint-node.js",
                    "~/Scripts/vendors/code-mirror/codemirror.js",
                    "~/Scripts/vendors/code-mirror/keymap/sublime.js",
                    "~/Scripts/vendors/code-mirror/lint/lint.js",
                    "~/Scripts/vendors/code-mirror/lint/css-lint.js",
                    "~/Scripts/vendors/code-mirror/hint/show-hint.js",
                    "~/Scripts/vendors/code-mirror/hint/css-hint.js",
                    "~/Scripts/vendors/code-mirror/mode/overlay.js",
                    "~/Scripts/vendors/code-mirror/mode/css.js",
                    "~/Scripts/vendors/code-mirror/fold/foldcode.js",
                    "~/Scripts/vendors/code-mirror/fold/foldgutter.js",
                    "~/Scripts/vendors/code-mirror/fold/brace-fold.js",
                    "~/Scripts/vendors/code-mirror/fold/comment-fold.js",
                    "~/Scripts/vendors/angular-ui-codemirror/ui-codemirror.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/adminApp")
                .Include("~/Scripts/app/_Common/app.common.js")
                .Include("~/Scripts/app/AdminBO/app.admin.bo.js")
                .Include("~/Scripts/app/_RouterConfig/app.admin.bo.routConfig.js")
                .IncludeDirectory("~/Scripts/app/_Common", "*.js", true)
                .IncludeDirectory("~/Scripts/app/AdminBO", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/resellerApp")
                .Include("~/Scripts/app/_Common/app.common.js")
                .Include("~/Scripts/app/ResellerBO/app.reseller.bo.js")
                .Include("~/Scripts/app/_RouterConfig/app.reseller.bo.routeConfig.js")
                .IncludeDirectory("~/Scripts/app/_Common", "*.js",true)
                .IncludeDirectory("~/Scripts/app/ResellerBO","*.js",true));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.css",
                      "~/Content/bootstrap/font-awesome.css",
                      "~/Content/bootstrap/ui-bootstrap-csp.css",
                      "~/Content/code-mirror/codemirror.css",
                      "~/Content/code-mirror/show-hint.css",
                      "~/Content/code-mirror/foldgutter.css",
                      "~/Content/code-mirror/night.css",
                      "~/Content/code-mirror/lint.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/loginCss").Include(
                      "~/Content/bootstrap/bootstrap.css",
                      "~/Content/login.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
