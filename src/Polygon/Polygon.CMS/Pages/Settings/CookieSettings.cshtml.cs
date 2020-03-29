using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.CMS.Business.Models;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Settings
{
    public class CookieSettings : SitePageModel
    {
        public CookieSettings(INavigationService navigationService)
            : base(navigationService)
        {
            
        }
    
        public void OnGet()
        {
            
        }
    }
}