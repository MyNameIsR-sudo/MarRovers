using System.Web.Mvc;
using System.Web.Routing;

namespace MarsRover
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{roverId}",
                defaults: new { controller = "Home", action = "Index", roverId = UrlParameter.Optional }
            );
        }
    }
}
