using Microsoft.AspNetCore.Mvc;
using Polygon.CMS.Business.Models;
using Polygon.Core.Data.Annotations;
using Polygon.Core.Data.Entities.Pages;
using Polygon.Core.Helpers;
using Polygon.Core.Services.Interfaces.Content;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Polygon.CMS.Pages.Content
{
    public class SelectPageTypeModel : SitePageModel
    {
        public SelectPageTypeModel(INavigationService navigationService)
            : base(navigationService)
        {
            ContentTypeAttributes = new List<ContentTypeAttribute>();
        }

        [BindProperty]
        public List<ContentTypeAttribute> ContentTypeAttributes { get; set; }

        [BindProperty]
        [Required]
        public string PageName { get; set; }

        public void OnGet()
        {
            var pageTypes = ContentHelper.GetEnumerableOfTypes<BasePage>();

            foreach (var pageType in pageTypes)
            {
                var contentTypeAttribute = AttributeHelper.GetContentTypeAttribute(pageType.GetType());
                ContentTypeAttributes.Add(contentTypeAttribute);
            }
        }
    }
}
