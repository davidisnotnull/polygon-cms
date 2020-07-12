using Microsoft.AspNetCore.Mvc;
using Polygon.CMS.Business.Models;
using Polygon.Core.Data.Annotations;
using Polygon.Core.Data.Entities.Pages;
using Polygon.Core.Helpers;
using Polygon.Core.Services.Interfaces.Content;
using System.Collections.Generic;

namespace Polygon.CMS.Pages.Content
{
    public class CreatePageModel : SitePageModel
    {
        public CreatePageModel(INavigationService navigationService)
            : base(navigationService)
        {
            ContentTypeAttribute = new List<ContentTypeAttribute>();
        }

        [BindProperty]
        public List<ContentTypeAttribute> ContentTypeAttribute { get; set; }

        public void OnGet()
        {
            var pageTypes = ContentHelper.GetEnumerableOfTypes<BasePage>();

            foreach (var pageType in pageTypes)
            {
                var contentTypeAttribute = AttributeHelper.GetContentTypeAttribute(pageType.GetType());
                ContentTypeAttribute.Add(contentTypeAttribute);
            }
        }
    }
}
