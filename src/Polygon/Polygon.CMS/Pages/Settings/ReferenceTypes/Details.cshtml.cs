using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Polygon.CMS.Business.Models;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Settings.ReferenceTypes
{
    public class DetailsModel : SitePageModel
    {
        private readonly IReferenceDataService _referenceDataService;

        public DetailsModel(INavigationService navigationService, IReferenceDataService referenceDataService)
            : base(navigationService)
        {
            _referenceDataService = referenceDataService;
        }

        [BindProperty]
        public ReferenceType ReferenceType { get; set; }

        [BindProperty]
        public List<ReferenceObject> ReferenceObjects { get; set; }

        public void OnGet(string guid)
        {
            var id = Guid.Parse(guid);
            ReferenceType = _referenceDataService.GetReferenceType(id);
            ReferenceObjects = _referenceDataService.GetReferenceObjectsByType(ReferenceType.Id).ToList();
        }
    }
}