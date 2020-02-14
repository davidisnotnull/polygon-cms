using Polygon.Core.Data.Entities.Taxonomy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.Pages
{
    public abstract class BasePage : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Heading { get; set; }

        public bool IsPublished { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
