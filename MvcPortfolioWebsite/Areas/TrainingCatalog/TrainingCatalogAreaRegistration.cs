using System.Web.Mvc;

namespace MvcPortfolioWebsite.Areas.TrainingCatalog
{
    public class TrainingCatalogAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TrainingCatalog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TrainingCatalog_default",
                "TrainingCatalog/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
