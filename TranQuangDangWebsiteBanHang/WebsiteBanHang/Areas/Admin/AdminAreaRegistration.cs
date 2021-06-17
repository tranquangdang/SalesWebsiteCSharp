using System.Web.Mvc;

namespace WebsiteBanHang.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Product_Create_default",
                "Admin/{controller}/{action}/{str}",
                new { controller = "Product", action = "Create", str = UrlParameter.Optional }
            );

            context.MapRoute(
                "User_Delete_default",
                "Admin/{controller}/{action}/{ID}",
                new { controller = "User", action = "Delete", ID = UrlParameter.Optional }
            );

            context.MapRoute(
                "Product_Delete_default",
                "Admin/{controller}/{action}/{ID}",
                new { controller = "Product", action = "Delete", ID = UrlParameter.Optional }
            );

            context.MapRoute(
                "Product_Index_default",
                "Admin/{controller}",
                new { controller = "Product", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}