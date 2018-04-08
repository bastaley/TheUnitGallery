using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TheUnitGallery
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;
            settings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "InvoiceOrder",
                "API/orders/invoice/{Id}",
                new { controller = "Orders", action = "InvoiceOrder" }
            );

            config.Routes.MapHttpRoute(
                "PayOrder",
                "API/orders/pay/{Id}",
                new { controller = "Orders", action = "PayOrder" }
            );

            config.Routes.MapHttpRoute(
                "CancelOrder",
                "API/orders/cancel/{Id}",
                new { controller = "Orders", action = "CancelOrder" }
            );


            config.Routes.MapHttpRoute(
                "GetOrdersItems",
                "API/orders/items/{Id}",
                new { controller = "Orders", action = "GetOrdersItems" }
            );

            config.Routes.MapHttpRoute(
                "GetCustomerItems",
                "API/orders/{Id}",
                new { controller = "Orders", action = "GetCustomerOrders" }
            );

            config.Routes.MapHttpRoute(
                "AddArtworkToOrder",
                "API/orders/add/{orderId}/{artworkId}",
                new { controller = "Orders", action = "AddArtworkToOrder" }
            );

            config.Routes.MapHttpRoute(
                "RemoveArtworkFromOrder",
                "API/orders/remove/{orderId}/{artworkId}",
                new { controller = "Orders", action = "RemoveArtworkFromOrder" }
            );


            config.Routes.MapHttpRoute(
                "ChangeCustomerAddress",
                "API/customers/{customerId}/{addressType}/{addressId}",
                new { controller = "Customers", action = "ChangeCustomerAddress" }
            );

            config.Routes.MapHttpRoute(
                "Interactions",
                "API/interactions/{customerId}/{interactionId}",
                new { controller = "Interactions", customerId = RouteParameter.Optional, interactionId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
