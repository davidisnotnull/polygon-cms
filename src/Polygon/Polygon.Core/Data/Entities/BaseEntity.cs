using System;
using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Created = DateTime.Now;
            IsDeleted = false;
        }

        [Required, Key]
        public int Id { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
