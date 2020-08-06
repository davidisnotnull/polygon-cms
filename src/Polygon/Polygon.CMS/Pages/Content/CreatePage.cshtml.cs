using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Polygon.CMS.Business.Models;
using Polygon.Core.Data.Annotations;
using Polygon.Core.Helpers;
using Polygon.Core.Models.UI;
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

        public List<PropertyInfo> PropertyInfo { get; set; }

        public void OnGet(string id)
        {
            var pageType = ContentHelper.GetTypeByGuid(id);
            ContentTypeAttribute = AttributeHelper.GetContentTypeAttribute(pageType);
            
            PropertyInfo = new List<PropertyInfo>();

            var propertyInfo = pageType.GetProperties();

            foreach (var prop in propertyInfo)
            {
                var propUiInfo = AttributeHelper.GetPropertyUiAttribute(prop);
            }
        }

        public void OnPost()
        {
            
        }
    }
}