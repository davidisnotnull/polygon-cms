using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.Pages
{
    public class StandardPage : BasePage
    {
        [Required]
        public string Heading { get; set; }
    }
}
