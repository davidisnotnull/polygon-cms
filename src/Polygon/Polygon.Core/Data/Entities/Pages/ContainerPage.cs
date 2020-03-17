using Polygon.Core.Constants;
using Polygon.Core.Data.Annotations;

namespace Polygon.Core.Data.Entities.Pages
{
    [ContentType(
        Guid = "c5b54342-21b5-412b-961e-830923dbe018",
        DisplayName = "Container Page",
        Description = "Used to create site structure for the content",
        GroupName = GroupNames.Pages.Utility
    )]
    public class ContainerPage : BasePage
    {
    }
}
