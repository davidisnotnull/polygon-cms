using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polygon.Core.Data.Entities.ReferenceData
{
    public class ReferenceObject : BaseEntity
    {
        [Required] 
        public string Name { get; set; }

        public Guid ReferenceTypeId { get; set; }

        public ReferenceType ReferenceType {get;set;}
    }
}
