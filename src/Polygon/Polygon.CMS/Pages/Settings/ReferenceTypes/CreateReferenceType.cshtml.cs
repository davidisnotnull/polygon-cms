using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Services.Interfaces.Content;
using System.ComponentModel.DataAnnotations;

namespace Polygon.CMS.Pages.Settings.ReferenceTypes
{
    public class CreateReferenceTypeModel : PageModel
    {
        private readonly IReferenceDataService _referenceDataService;

        public CreateReferenceTypeModel(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [BindProperty]
        public string ReferenceTypeName { get; set; }

        [BindProperty]
        public string ReferenceTypeDescription { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var referenceType = new ReferenceType
            {
                Name = ReferenceTypeName,
                Description = ReferenceTypeDescription
            };

            _referenceDataService.CreateReferenceType(referenceType);
            return StatusCode(200);
        }
    }
}