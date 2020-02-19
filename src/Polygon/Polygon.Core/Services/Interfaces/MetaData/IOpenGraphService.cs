using System.Collections.Generic;

namespace Polygon.Core.Services.Interfaces.MetaData
{
    public interface IOpenGraphService
    {
        IEnumerable<KeyValuePair<int, string>> GetOpenGraphTypes();

        /// <summary>
        /// Gets the Open Graph Type Namespace to render as an attribute in the View meta data
        /// </summary>
        /// <param name="id">Open Graph Type Id</param>
        /// <returns></returns>
        string GetOpenGraphNamespace(int id);

        /// <summary>
        /// Gets the Open Graph type to render as an attribute in the View meta data
        /// </summary>
        /// <param name="id">Open Graph Type Id</param>
        /// <returns></returns>
        string GetOpenGraphType(int id);
    }
}
