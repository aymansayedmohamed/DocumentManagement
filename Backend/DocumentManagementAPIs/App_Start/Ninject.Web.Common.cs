[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DocumentManagementAPIs.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DocumentManagementAPIs.App_Start.NinjectWebCommon), "Stop")]

namespace DocumentManagementAPIs.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Business;
    using DataAccess;
    using DocumentManagementLogger;
    using IBusiness;
    using IDataAccess;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InThreadScope();

            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InTransientScope();

            kernel.Bind<ILogger>().To<FileLogger>().InSingletonScope();

            kernel.Bind<IDocumentManager>().To<DocumentManager>().InTransientScope();

            kernel.Bind<IAccountManager>().To<AccountManager>().InTransientScope();

            kernel.Bind<IFileHelper>().To<FileHelper>().InTransientScope();

        }
    }
}