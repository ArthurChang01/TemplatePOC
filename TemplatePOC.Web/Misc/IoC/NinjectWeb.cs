[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TemplatePOC.Web.Misc.IoC.NinjectWeb), "Start")]

namespace TemplatePOC.Web.Misc.IoC
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject.Web;

    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
