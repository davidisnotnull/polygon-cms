using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.Core.Data.Entities.ReferenceData;
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
        
        [BindProperty]
        public ReferenceCollection ReferenceCollection { get; set; }

        public void OnGet(string id)
        {
            var guid = Guid.Parse(id);
            ReferenceCollection = _referenceDataService.GetReferenceCollection(guid);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _referenceDataService.UpdateReferenceCollection(ReferenceCollection);
            return StatusCode(200);
        }
    }
}