using Microsoft.AspNetCore.Mvc;
using Polygon.CMS.Business.Models;
using Polygon.Core.Data.Annotations;
using Polygon.Core.Helpers;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Content
{
    public class CreatePageModel : SitePageModel
    {
        public CreatePageModel(INavigationService navigationService)
            : base(navigationService)
        {
            
        }

        [BindProperty]
        public ContentTypeAttribute ContentTypeAttribute { get; set; }


        public void OnGet(string id)
        {
            var pageType = ContentHelper.GetTypeByGuid(id);
            ContentTypeAttribute = AttributeHelper.GetContentTypeAttribute(pageType);
        }
    }
}