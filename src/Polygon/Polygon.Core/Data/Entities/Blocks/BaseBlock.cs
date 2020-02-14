using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.Blocks
{
    public abstract class BaseBlock : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
