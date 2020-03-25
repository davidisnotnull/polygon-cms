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
        public ReferenceCollection ReferenceCollection { get; set; }

        [BindProperty]
        public List<ReferenceItem> ReferenceItems { get; set; }

        public void OnGet(string guid)
        {
            ReferenceCollection = _referenceDataService.GetReferenceCollection(Guid.Parse(guid));
            ReferenceItems = _referenceDataService.GetReferenceItemsByCollection(ReferenceCollection.Id).ToList();
        }
    }
}