using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polygon.Core.Enums.OpenGraph;
using Polygon.Core.Extensions;

namespace Polygon.Core.UnitTests.Extensions
{
    [TestClass]
    public class EnumExtensionTests
    {
        [TestMethod]
        public void Can_Get_Enum_Name()
        {
            var enumName = OpenGraphTypes.Article.GetName();
            Assert.AreEqual("Article", enumName);
        }

        [TestMethod]
        public void Can_Get_Enum_Value()
        {
            var enumValue = OpenGraphTypes.Article.GetValue();
            Assert.AreEqual(9, enumValue);
        }

        [TestMethod]
        public void Can_Get_Enum_Description()
        {
            var enumDescription = OpenGraphTypes.Article.GetDescription();
            Assert.AreEqual("article", enumDescription);
        }
    }
}
