using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Settings.ReferenceData
{
    public class CreateReferenceItemModel : PageModel
    {
        private readonly IReferenceDataService _referenceDataService;

        public CreateReferenceItemModel(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }
        
        [BindProperty]
        public string ReferenceCollectionId { get; set; }
        
        [Required]
        [StringLength(60, MinimumLength = 3)]
        [BindProperty]
        public string ReferenceItemName { get; set; }
        
        public void OnGet(string id)
        {
            ReferenceCollectionId = id;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            
            var referenceObjectToCreate = new ReferenceItem()
            {
                Name = ReferenceItemName,
                ReferenceCollectionId = Guid.Parse(ReferenceCollectionId)
            };
            _referenceDataService.CreateReferenceItem(referenceObjectToCreate);
            return StatusCode(200);
        }
    }
}