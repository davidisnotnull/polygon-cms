using System.Collections.Generic;
using Polygon.Core.Services.Interfaces.MetaData;

namespace Polygon.Core.Services.MetaData
{
    public class OpenGraphService : IOpenGraphService
    {
        public OpenGraphService()
        { }

        public IEnumerable<KeyValuePair<int, string>> GetOpenGraphTypes()
        {
            throw new System.NotImplementedException();
        }

        public string GetOpenGraphNamespace(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetOpenGraphType(int id)
        {
            throw new System.NotImplementedException();
        }
        
    }
}
