using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Settings.ReferenceData
{
    public class DeleteReferenceItemModel : PageModel
    {
        private IReferenceDataService _referenceDataService;

        public DeleteReferenceItemModel(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }
        
        [Required]
        [BindProperty]
        public string ReferenceItemId { get; set; }
        
        [BindProperty]
        public string ReferenceItemName { get; set; }
        
        public void OnGet(string id)
        {
            ReferenceItemId = id;
            ReferenceItemName = _referenceDataService.GetReferenceItem(Guid.Parse(id)).Name;
        }

        public StatusCodeResult OnPost()
        {
            
            return new StatusCodeResult(200);
        }
    }
}