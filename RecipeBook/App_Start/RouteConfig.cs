using System.Web.Mvc;
using System.Web.Routing;

namespace RecipeBook
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Category",
                "categories/{id}",
                new { controller = "CategoriesMVC", action = "Details" }
            );

            routes.MapRoute(
                "Recipe",
                "recipes/{id}",
                new { controller = "RecipesMVC", action = "Details" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
