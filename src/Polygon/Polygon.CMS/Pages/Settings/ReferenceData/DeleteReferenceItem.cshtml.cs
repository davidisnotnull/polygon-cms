﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Polygon.Core.Data.Entities.ReferenceData;
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
        public ReferenceItem ReferenceItem { get; set; }
        
        public void OnGet(string id)
        {
            ReferenceItem = _referenceDataService.GetReferenceItem(Guid.Parse(id));
        }

        public IActionResult OnPost()
        {
            _referenceDataService.DeleteReferenceItem(ReferenceItem.Id);
            return new StatusCodeResult(200);
        }
    }
}