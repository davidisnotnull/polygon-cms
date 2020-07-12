using Polygon.Core.Data.Entities.Shared;
using Polygon.Core.Data.Entities.Taxonomy;
using Polygon.Core.Enums.OpenGraph;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Polygon.Core.Constants;
using Polygon.Core.Data.Annotations;

namespace Polygon.Core.Data.Entities.Pages
{
    [ContentType(
        Guid = "3e02ab65-3393-47c4-a988-9ad6be6535e9",
        DisplayName = "Standard Page",
        Description = "Used to create a Standard Page for the site",
        GroupName = GroupNames.Pages.Content
    )]
    public class StandardPage : BasePage, IMetaData, ITags, ICategories
    {
        [Required]
        public string Heading { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public OpenGraphTypes OpenGraphType { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }
    }
}
