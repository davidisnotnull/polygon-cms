using Polygon.Core.Constants;
using Polygon.Core.Data.Annotations;

namespace Polygon.Core.Data.Entities.Pages
{
    [ContentType(
        Guid = "c9a05908-061f-416c-a2e3-336ce004d204",
        DisplayName = "Home Page",
        Description = "Used to create a Home Page for the site",
        GroupName = GroupNames.Pages.Content
        )]
    public class HomePage : BasePage
    {
    }
}
