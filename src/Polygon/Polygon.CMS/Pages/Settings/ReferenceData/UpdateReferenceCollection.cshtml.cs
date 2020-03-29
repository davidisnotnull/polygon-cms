using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Settings.ReferenceData
{
    public class UpdateReferenceCollectionModel : PageModel
    {
        private IReferenceDataService _referenceDataService;

        public UpdateReferenceCollectionModel(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }

        public void OnGet()
        {

        }
    }
}