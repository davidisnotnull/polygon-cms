using System;
using System.ComponentModel.DataAnnotations;
using Polygon.Core.Data.Annotations;
using Polygon.Core.Enums.Editor;

namespace Polygon.Core.Data.Entities.Pages
{
    public abstract class BasePage : BaseEntity, IComparable<BasePage>
    {
        protected BasePage()
        {
            IsPublished = false;
        }
        
        [Required]
        [PropertyUi(
            UIType = UIType.Textbox,
            Description = "This is the name of your Page as it appears in the CMS.",
            Placeholder = "Enter the name of your page"
        )]
        public string Name { get; set; }

        public bool IsPublished { get; set; }

        public int ParentPageId { get; set; }

        public int CompareTo(BasePage other)
        {
            if (ReferenceEquals(this, other)) 
                return 0;

            if (ReferenceEquals(null, other))
                return 1;

            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) 
                return nameComparison;
            
            var isPublishedComparison = 
                IsPublished.CompareTo(other.IsPublished);
            
            if (isPublishedComparison != 0) 
                return isPublishedComparison;
            
            return ParentPageId.CompareTo(other.ParentPageId);
        }
    }
}
