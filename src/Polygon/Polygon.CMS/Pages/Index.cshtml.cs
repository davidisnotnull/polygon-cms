using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.Core.Models.Navigation;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INavigationService _navigationService;

        public MenuBuilder MainMenu;

        public Breadcrumb Breadcrumb;

        public IndexModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MainMenu = _navigationService.GetAdminMainNavigation();
            Breadcrumb = new Breadcrumb(MainMenu.MenuItems);
        }

        public void OnGet()
        {

        }
    }
}
