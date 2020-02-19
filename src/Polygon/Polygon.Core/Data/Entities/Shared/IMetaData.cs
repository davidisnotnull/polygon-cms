using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.Shared
{
    public interface IMetaData
    {
        [Required]
        public string MetaTitle { get; set; }

        [Required]
        public string MetaDescription { get; set; }
    }
}
