using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace webapif
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //api/serverdata/type/valor
            config.Routes.MapHttpRoute(
                 name: "ProductByType",
                 routeTemplate: "api/{controller}/type/{type}"
               );
            //api/serverdata/ip/valor
            config.Routes.MapHttpRoute(
                name: "ProductByIP",
                routeTemplate: "api/{controller}/ip/{ip}"
            );

            //return JSON response by default  
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
