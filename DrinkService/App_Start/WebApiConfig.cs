using System.Web.Http;
using Microsoft.Practices.Unity;
using DrinkService.WebApi.IoC;
using CoreServices = DrinkService.Core.Services;
using DrinkService.Core.Repositories;
using DrinkService.Core.Validation;
using DrinkService.InMemoryRepository;

namespace DrinkService.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<CoreServices.IDrinkService, CoreServices.DrinkService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDrinkValidator, DrinkValidator>(new HierarchicalLifetimeManager());
            container.RegisterType<IDrinkRepository, DrinkRepository>(new ContainerControlledLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
