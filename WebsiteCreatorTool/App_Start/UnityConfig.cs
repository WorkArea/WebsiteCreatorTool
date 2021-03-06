using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
//using WebsiteCreatorTool.Domain.Contracts;
//using WebsiteCreatorTool.Domain.Handlers;
//using WebsiteCreatorTool.Data;
//using WebsiteCreatorTool.Data.Sql.Repositories;

namespace WebsiteCreatorTool.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            //Method 1: using unity container
            container.LoadConfiguration("container");

            // Method 2: by defining mappings explicitly
            //container.RegisterType<WebsiteCreatorTool.Data.IUnitOfWork, WebsiteCreatorTool.Data.Sql.WebsiteCreatorToolDbContext>();
            //container.RegisterType<WebsiteCreatorTool.Domain.Contracts.ISampleService, WebsiteCreatorTool.Domain.Handlers.SampleService>();
            //container.RegisterType<WebsiteCreatorTool.Data.ISampleRepository, WebsiteCreatorTool.Data.Sql.Repositories.SampleRepository>();
        }
    }
}
