using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polygon.Core.Enums.OpenGraph;
using Polygon.Core.Services.Interfaces.MetaData;
using Polygon.Core.Services.MetaData;

namespace Polygon.Core.UnitTests.Services.MetaData
{
    [TestClass]
    public class OpenGraphServiceTests
    {
        private IOpenGraphService _openGraphService;

        [TestInitialize]
        public void Initialize()
        {
            _openGraphService = new OpenGraphService();
        }

        [TestMethod]
        public void Can_Get_Open_Graph_Types()
        {
            var selectBuilder = _openGraphService.GetOpenGraphTypes();
            Assert.AreEqual(12, selectBuilder.Items.Count);
        }

        [TestMethod]
        public void Can_Order_Types_By_Ascending()
        {
            var selectBuilder = _openGraphService.GetOpenGraphTypes();
            selectBuilder.OrderByAscending();
            Assert.AreEqual("Article", selectBuilder.Items[0].Value);
        }

        [TestMethod]
        public void Can_Get_Open_Graph_Type_Schema()
        {
            var openGraphDescription = _openGraphService.GetOpenGraphTypeSchema(OpenGraphTypes.MusicAlbum);
            Assert.AreEqual("music.album", openGraphDescription);
        }

        [TestMethod]
        public void Can_Get_Open_Graph_Namespace_Schema()
        {
            var openGraphNamespaceSchema = _openGraphService.GetOpenGraphNamespaceSchema(OpenGraphTypes.MusicAlbum);
            Assert.AreEqual("http://ogp.me/ns/music#", openGraphNamespaceSchema);
        }
    }
}
