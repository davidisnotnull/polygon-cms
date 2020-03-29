using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Services.Interfaces.Content;
using System.ComponentModel.DataAnnotations;

namespace Polygon.CMS.Pages.Settings.ReferenceData
{
    public class CreateReferenceCollectionModel : PageModel
    {
        private readonly IReferenceDataService _referenceDataService;

        public CreateReferenceCollectionModel(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [BindProperty]
        public string ReferenceCollectionName { get; set; }

        [Required]
        [BindProperty]
        public string ReferenceCollectionDescription { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var referenceCollection = new ReferenceCollection
            {
                Name = ReferenceCollectionName,
                Description = ReferenceCollectionDescription
            };

            _referenceDataService.CreateReferenceCollection(referenceCollection);
            return StatusCode(200);
        }
    }
}