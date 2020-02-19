using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Data.Entities.Blocks
{
    public class TeaserBlock : BaseBlock
    {
        [Required]
        public string Heading { get; set; }

        public string MainBody { get; set; }
        
        public string TeaserImage { get; set; }
        
        public bool HasButton { get; set; }

        public string ButtonText { get; set; }

        public string HeadingLinkUrl { get; set; }

        public string ButtonLinkUrl { get; set; }
    }
}
