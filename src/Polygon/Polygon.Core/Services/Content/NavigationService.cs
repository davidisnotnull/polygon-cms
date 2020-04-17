using Polygon.Core.Data.Interfaces;
using Polygon.Core.Models.Navigation;
using Polygon.Core.Services.Interfaces.Content;
using System.Collections.Generic;

namespace Polygon.Core.Services.Content
{
    public class NavigationService : BaseService, INavigationService
    {
        public NavigationService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public MenuBuilder GetAdminMainNavigation() => new MenuBuilder
        {
            MenuItems = new List<MenuItem> {
                new MenuItem { Name = "Content", Link = "Content" },
                new MenuItem { Name = "User", Link = "Users" },
                new MenuItem { Name = "Settings", Link = "Settings" },
                new MenuItem { Name = "Developer", Link = "Developer"}
            }
        };

        public Breadcrumb GetBreadcrumbs()
        {
            throw new System.NotImplementedException();
        }
    }
}
