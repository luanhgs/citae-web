using System.Web;
using System.Web.Optimization;

namespace Citae_Application
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Todos os arquivos de script
            bundles.Add(new ScriptBundle("~/Scripts/base-javascript").Include(
                        "~/Scripts/citae-script.js"));
            bundles.Add(new ScriptBundle("~/Scripts/detail-javascript").Include(
                        "~/Scripts/detail-script.js"));

            //Todos os arquivos de estlização
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/citae-layout.css",
                      "~/Content/user-layout.css",
                      "~/Content/normalize.css"));
            bundles.Add(new StyleBundle("~/Content/detail-css").Include(
                      "~/Content/detail-layout.css"));
        }
    }
}
