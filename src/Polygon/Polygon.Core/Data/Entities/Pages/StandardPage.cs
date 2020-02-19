using Polygon.Core.Data.Entities.Shared;
using Polygon.Core.Data.Entities.Taxonomy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.Pages
{
    public class StandardPage : BasePage, IMetaData, ITags, ICategories
    {
        [Required]
        public string Heading { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }
    }
}
