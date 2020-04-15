using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Settings.ReferenceTypes
{
    public class ManageReferenceItemModel : PageModel
    {
        private readonly IReferenceDataService _referenceDataService;
        
        public ManageReferenceItemModel(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }

        [BindProperty]
        public bool Edit { get; set; }

        [Required]
        [BindProperty]
        public ReferenceCollection ReferenceCollection { get; set; }

        [BindProperty]
        public string ReferenceCollectionId { get; set; }

        [BindProperty]
        public string ReferenceItemId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [BindProperty]
        public string ReferenceItemName { get; set; }

        public void OnGet(string id, bool edit)
        {
            Edit = edit;
            switch (Edit)
            {
                case true: // If edit mode
                    var referenceObject = _referenceDataService.GetReferenceItem(Guid.Parse(id));
                    ReferenceItemName = referenceObject.Name;
                    ReferenceItemId = referenceObject.Id.ToString();
                    break;
                case false:
                    ReferenceCollectionId = id;
                    ReferenceCollection = _referenceDataService.GetReferenceCollection(Guid.Parse(id));
                    break;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            
            switch (Edit)
            {
                case true: // If edit mode
                    var referenceObjectToUpdate = _referenceDataService.GetReferenceItem(Guid.Parse(ReferenceItemId));
                    referenceObjectToUpdate.Name = ReferenceItemName;
                    _referenceDataService.UpdateReferenceItem(referenceObjectToUpdate);
                    return StatusCode(200);
                case false:
                    return StatusCode(200);
            }
        }
    }
}