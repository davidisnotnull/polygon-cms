using Polygon.Core.Models.Navigation;

namespace Polygon.Core.Services.Interfaces.Content
{
    public interface INavigationService
    {
        public MenuBuilder GetAdminMainNavigation();

        public Breadcrumb GetBreadcrumbs();
    }
}
