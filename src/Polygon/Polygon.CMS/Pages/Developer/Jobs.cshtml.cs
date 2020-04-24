using Polygon.CMS.Business.Models;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Developer
{
    public class JobsModel : SitePageModel
    {
        public JobsModel(INavigationService navigationService) 
            : base(navigationService)
        {
            
        }

        public void OnGet()
        {

        }
    }
}