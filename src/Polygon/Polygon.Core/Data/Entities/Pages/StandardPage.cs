using Polygon.Core.Constants;
using Polygon.Core.Data.Annotations;
using Polygon.Core.Data.Entities.Shared;
using Polygon.Core.Data.Entities.Taxonomy;
using Polygon.Core.Enums.Editor;
using Polygon.Core.Enums.OpenGraph;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [PropertyUi(
            UIType = UIType.Textbox,
            DisplayName = "Main Heading (H1)",
            Placeholder = "Enter the main heading for your page",
            GroupName = GroupNames.Pages.Content
        )]
        public string Heading { get; set; }

        [PropertyUi(
            UIType = UIType.Wysiwyg,
            DisplayName = "Main Body",
            Placeholder = "Enter your main body text",
            GroupName = GroupNames.Pages.Content
        )]
        public string MainBody { get; set; }

        [PropertyUi(
            UIType = UIType.Textbox,
            DisplayName = "Meta Title",
            GroupName = GroupNames.Pages.Metadata
        )]
        public string MetaTitle { get; set; }

        [PropertyUi(
            GroupName = GroupNames.Pages.Metadata
        )]
        public string MetaDescription { get; set; }

        [PropertyUi(
            GroupName = GroupNames.Pages.Metadata
        )]
        public OpenGraphTypes OpenGraphType { get; set; }

        [PropertyUi(
            UIType = UIType.Textbox,
            GroupName = GroupNames.Pages.Utility
        )]
        public IEnumerable<Tag> Tags { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }
    }
}
