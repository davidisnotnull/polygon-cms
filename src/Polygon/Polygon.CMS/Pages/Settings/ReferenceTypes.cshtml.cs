using Polygon.CMS.Business.Models;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Settings
{
    public class ReferenceTypesModel : SitePageModel
    {
        private readonly IReferenceDataService _referenceDataService;

        public ReferenceTypesModel(INavigationService navigationService, IReferenceDataService referenceDataService)
            : base(navigationService)
        {
            _referenceDataService = referenceDataService;
        }

        public void OnGet()
        {

        }
    }
}