using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Polygon.Core.Data.Annotations;

namespace Polygon.Core.Data.Entities.ReferenceData
{
    [ContentType(
        Guid = "ceaa6956-12cf-4078-a32c-e84e125d80f9",
        DisplayName = "Reference Collection",
        Description = "Used to logically group Reference Items"
    )]
    public class ReferenceCollection : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<ReferenceItem> ReferenceItems { get; set; }

    }
}
