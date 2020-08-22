using Microsoft.AspNetCore.Mvc;
using Polygon.CMS.Business.Models;
using Polygon.Core.Data.Annotations;
using Polygon.Core.Helpers;
using Polygon.Core.Models.UI;
using Polygon.Core.Services.Interfaces.Content;
using System.Collections.Generic;

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

        [BindProperty]
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

                if (propUiInfo == null)
                    continue;

                var propInfo = new PropertyInfo
                {
                    Name = prop.Name,
                    DisplayName = string.IsNullOrEmpty(propUiInfo.DisplayName) ? prop.Name : propUiInfo.DisplayName,
                    Description = string.IsNullOrEmpty(propUiInfo.Description) ? "" : propUiInfo.Description,
                    Placeholder = string.IsNullOrEmpty(propUiInfo.Placeholder) ? $"Enter the {prop.Name}" : propUiInfo.Placeholder,
                    UIType = propUiInfo.UIType
                };

                PropertyInfo.Add(propInfo);
            }
        }

        public void OnPost()
        {
            
        }
    }
}