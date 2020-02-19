using Polygon.Core.Enums.OpenGraph;

namespace Polygon.Core.Data.Entities.Shared
{
    public interface IMetaData
    {
        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public OpenGraphTypes OpenGraphType { get; set; }
    }
}
