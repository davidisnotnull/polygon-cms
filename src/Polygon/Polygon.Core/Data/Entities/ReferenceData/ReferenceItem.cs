using System;
using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.ReferenceData
{
    public class ReferenceItem : BaseEntity
    {
        [Required] 
        public string Name { get; set; }

        public Guid ReferenceCollectionId { get; set; }

        public ReferenceCollection ReferenceCollection { get; set;}
    }
}
