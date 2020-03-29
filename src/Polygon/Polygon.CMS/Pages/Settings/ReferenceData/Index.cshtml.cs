using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Polygon.CMS.Business.Models;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Settings.ReferenceData
{
    public class ReferenceCollectionsModel : SitePageModel
    {
        private readonly IReferenceDataService _referenceDataService;

        public ReferenceCollectionsModel(INavigationService navigationService, IReferenceDataService referenceDataService)
            : base(navigationService)
        {
            _referenceDataService = referenceDataService;
        }

        [BindProperty]
        public List<ReferenceCollection> ReferenceCollections { get; set; }

        public void OnGet()
        {
            ReferenceCollections = _referenceDataService.GetAllReferenceCollections().ToList();
        }
    }
}