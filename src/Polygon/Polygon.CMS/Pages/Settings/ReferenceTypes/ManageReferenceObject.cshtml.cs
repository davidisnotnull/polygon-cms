using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Settings.ReferenceTypes
{
    public class ManageReferenceObjectModel : PageModel
    {
        private readonly IReferenceDataService _referenceDataService;

        public ManageReferenceObjectModel(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }

        [Required]
        [BindProperty]
        public ReferenceType ReferenceType { get; set; }

        [BindProperty]
        public string ReferenceTypeId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [BindProperty]
        public string ReferenceObjectName { get; set; }

        public void OnGet(string id)
        {
            ReferenceTypeId = id;
            var guid = Guid.Parse(id);
            ReferenceType = _referenceDataService.GetReferenceType(guid);
        }

        public IActionResult OnPost()
        {
            var referenceTypeId = Guid.Parse(ReferenceTypeId);
            var referenceObject = new ReferenceObject()
            {
                Name = ReferenceObjectName,
                ReferenceTypeId = referenceTypeId
            };

            _referenceDataService.CreateReferenceObject(referenceObject);

            return StatusCode(200);
        }
    }
}