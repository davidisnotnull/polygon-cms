﻿using Polygon.CMS.Business.Models;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Pages.Users
{
    public class IndexModel : SitePageModel
    {
        public IndexModel(INavigationService navigationService) 
            : base(navigationService)
        {
            
        }

        public void OnGet()
        {

        }
    }
}