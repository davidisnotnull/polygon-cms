using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Settings.ReferenceData
{
    public class UpdateReferenceItem : PageModel
    {
        private IReferenceDataService _referenceDataService;

        public UpdateReferenceItem(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }
        
        [Required]
        [BindProperty]
        public ReferenceItem ReferenceItem { get; set; }
        
        public void OnGet(string id)
        {
            ReferenceItem = _referenceDataService.GetReferenceItem(Guid.Parse(id));
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var referenceItemToUpdate = _referenceDataService.GetReferenceItem(ReferenceItem.Id);
            referenceItemToUpdate.Modified = DateTime.Now;
            referenceItemToUpdate.Name = ReferenceItem.Name;
            _referenceDataService.UpdateReferenceItem(referenceItemToUpdate);
            
            return StatusCode(200);
        }
    }
}