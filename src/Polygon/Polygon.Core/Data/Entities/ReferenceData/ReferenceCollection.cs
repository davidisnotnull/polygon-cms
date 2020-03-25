using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.ReferenceData
{
    public class ReferenceCollection : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<ReferenceItem> ReferenceItems { get; set; }

    }
}
