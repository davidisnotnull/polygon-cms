using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.ReferenceData
{
    public class ReferenceObject : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public ReferenceType ReferenceType {get;set;}
    }
}
