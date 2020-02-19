using Polygon.Core.Enums.OpenGraph;
using Polygon.Core.Models.Selection;

namespace Polygon.Core.Services.Interfaces.MetaData
{
    public interface IOpenGraphService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SelectBuilder GetOpenGraphTypes();

        /// <summary>
        /// Gets the Open Graph Type Namespace to render as an attribute in the View meta data
        /// </summary>
        /// <param name="openGraphType"></param>
        /// <returns></returns>
        string GetOpenGraphNamespaceSchema(OpenGraphTypes openGraphType);

        /// <summary>
        /// Gets the Open Graph type to render as an attribute in the View meta data
        /// </summary>
        /// <param name="openGraphType"></param>
        /// <returns></returns>
        string GetOpenGraphTypeSchema(OpenGraphTypes openGraphType);
    }
}
