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

        [BindProperty]
        public bool Edit { get; set; }

        [Required]
        [BindProperty]
        public ReferenceType ReferenceType { get; set; }

        [BindProperty]
        public string ReferenceTypeId { get; set; }

        [BindProperty]
        public string ReferenceObjectId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [BindProperty]
        public string ReferenceObjectName { get; set; }

        public void OnGet(string id, bool edit)
        {
            Edit = edit;
            switch (Edit)
            {
                case true: // If edit mode
                    var referenceObject = _referenceDataService.GetReferenceObject(Guid.Parse(id));
                    ReferenceObjectName = referenceObject.Name;
                    ReferenceObjectId = referenceObject.Id.ToString();
                    break;
                case false:
                    ReferenceTypeId = id;
                    ReferenceType = _referenceDataService.GetReferenceType(Guid.Parse(id));
                    break;
            }
        }

        public IActionResult OnPost()
        {
            switch (Edit)
            {
                case true: // If edit mode
                    var referenceObjectToUpdate = _referenceDataService.GetReferenceObject(Guid.Parse(ReferenceObjectId));
                    referenceObjectToUpdate.Name = ReferenceObjectName;
                    _referenceDataService.UpdateReferenceObject(referenceObjectToUpdate);
                    return StatusCode(200);
                case false:
                    var referenceObjectToCreate = new ReferenceObject()
                    {
                        Name = ReferenceObjectName,
                        ReferenceTypeId = Guid.Parse(ReferenceTypeId)
                    };
                    _referenceDataService.CreateReferenceObject(referenceObjectToCreate);
                    return StatusCode(200);
            }
        }
    }
}