using System.Web.Mvc;

namespace MvcPortfolioWebsite.Areas.CrudDemo
{
    public class CrudDemoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CrudDemo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CrudDemo_default",
                "CrudDemo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
