using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.Pages
{
    public abstract class BasePage : BaseEntity
    {
        protected BasePage()
        {
            IsPublished = false;
        }
        
        [Required]
        public string Name { get; set; }

        public bool IsPublished { get; set; }

        public int ParentPageId { get; set; }
    }
}
