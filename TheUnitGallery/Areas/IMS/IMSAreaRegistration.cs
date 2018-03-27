using System.Web.Mvc;

namespace TheUnitGallery.Areas.IMS
{
    public class IMSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "IMS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
            name: "AddressEditByCustomer",
            url: "IMS/Addresses/Edit/{customerId}/{Id}",
            defaults: new { controller = "Addresses", action = "Edit", area = "IMS" }
            );

            context.MapRoute(
                "IMS_default",
                "IMS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}