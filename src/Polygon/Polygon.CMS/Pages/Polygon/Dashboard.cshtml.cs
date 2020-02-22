using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.Core.Models.Navigation;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Polygon
{
    public class DashboardModel : PageModel
    {
        private readonly INavigationService _navigationService;

        public MenuBuilder MainMenu;

        public DashboardModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MainMenu = _navigationService.GetAdminMainNavigation();
        }

        public void OnGet()
        {

        }
    }
}
