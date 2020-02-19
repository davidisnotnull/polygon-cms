using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.Blocks
{
    public abstract class BaseBlock : BaseEntity
    {
        protected BaseBlock()
        {
            IsPublished = false;
        }
        
        [Required]
        public string Name { get; set; }

        public bool IsPublished { get; set; }
    }
}
