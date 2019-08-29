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
            bundles.Add(new ScriptBundle("~/Scripts/javascript").Include(
                        "~/Scripts/citae-script.js")); 

            //Todos os arquivos de estlização
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/citae-style.css"));
        }
    }
}
