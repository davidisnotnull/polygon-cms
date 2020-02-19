using Polygon.Core.Enums.OpenGraph;
using Polygon.Core.Extensions;
using Polygon.Core.Models.Selection;
using Polygon.Core.Services.Interfaces.MetaData;
using System;
using System.Linq;

namespace Polygon.Core.Services.MetaData
{
    public class OpenGraphService : IOpenGraphService
    {

        public SelectBuilder GetOpenGraphTypes()
        {
            var selectBuilder = new SelectBuilder();

            foreach (var openGraphType in (OpenGraphTypes[]) Enum.GetValues(typeof(OpenGraphTypes)))
            {
                selectBuilder.AddItemToSelectList(openGraphType.GetValue(), openGraphType.GetDisplayName());
            }

            selectBuilder.OrderByAscending();
            return selectBuilder;
        }

        public string GetOpenGraphNamespaceSchema(OpenGraphTypes openGraphType)
        {
            var openGraphSchema= openGraphType.GetDescription().GetUntilCharacterOrEmpty();
            var openGraphNamespaces = Enum.GetNames(typeof(OpenGraphNamespaces));
            var matchingNamespace = openGraphNamespaces.SingleOrDefault(x => x.StartsWith(openGraphSchema, StringComparison.OrdinalIgnoreCase));
            var matchingNamespaceEnum = (OpenGraphNamespaces)Enum.Parse(typeof(OpenGraphNamespaces), matchingNamespace);

            return matchingNamespaceEnum.GetDescription();
        }

        public string GetOpenGraphTypeSchema(OpenGraphTypes openGraphType)
        {
            return openGraphType.GetDescription();
        }
        
    }
}
