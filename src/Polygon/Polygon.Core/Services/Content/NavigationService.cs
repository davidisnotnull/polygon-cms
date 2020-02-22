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
                new MenuItem { Name = "Content", Area = "Polygon", Link = "Content" },
                new MenuItem { Name = "User", Area = "Polygon", Link = "Users" },
                new MenuItem { Name = "Settings", Area = "Polygon", Link = "Settings" }
            }
        };

        public Breadcrumb GetBreadcrumbs()
        {
            throw new System.NotImplementedException();
        }
    }
}
