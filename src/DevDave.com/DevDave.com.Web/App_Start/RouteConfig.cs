using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RouteMagic;

namespace DevDave.Com.Web
{
    /// <summary>
    /// Route Config
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            // old routes, permenant redirects
            var homeRoute = routes.MapRoute("Home", "Home", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            var aboutRoute = routes.MapRoute("About", "About", new { controller = "Home", action = "About", id = UrlParameter.Optional });
            var resumeRoute = routes.MapRoute("Resume", "Resume", new { controller = "Home", action = "Resume", id = UrlParameter.Optional });
            routes.Redirect(r => r.MapRoute("oldHome", "Home"), true).To(homeRoute);
            routes.Redirect(r => r.MapRoute("oldAboutMe", "AboutMe"), true).To(aboutRoute);
            routes.Redirect(r => r.MapRoute("oldAboutSite", "AboutSite"), true).To(aboutRoute);
            routes.Redirect(r => r.MapRoute("oldResume", "Resume"), true).To(resumeRoute);
            routes.Redirect(r => r.MapRoute("oldProjects", "Projects"), true).To(homeRoute);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}