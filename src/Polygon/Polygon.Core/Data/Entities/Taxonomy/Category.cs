using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.Taxonomy
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
