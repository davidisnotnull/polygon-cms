using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.Taxonomy
{
    public class Tag : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
