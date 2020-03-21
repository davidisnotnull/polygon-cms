using Microsoft.AspNetCore.Mvc;
using Polygon.CMS.Business.Models;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Services.Interfaces.Content;
using System.Collections.Generic;
using System.Linq;

namespace Polygon.CMS.Pages.Settings.ReferenceTypes
{
    public class ReferenceTypesModel : SitePageModel
    {
        private readonly IReferenceDataService _referenceDataService;

        public ReferenceTypesModel(INavigationService navigationService, IReferenceDataService referenceDataService)
            : base(navigationService)
        {
            _referenceDataService = referenceDataService;
        }

        [BindProperty]
        public List<ReferenceType> ReferenceTypes { get; set; }

        public void OnGet()
        {
            ReferenceTypes = _referenceDataService.GetAllReferenceTypes().ToList();
        }
    }
}