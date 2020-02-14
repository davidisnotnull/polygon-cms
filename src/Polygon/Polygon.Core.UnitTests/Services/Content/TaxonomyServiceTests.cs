using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polygon.Core.Data;
using Polygon.Core.Data.Entities.Taxonomy;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using Polygon.Core.Services.Content;
using Polygon.Core.Services.Interfaces.Content;
using Polygon.Core.UnitTests.Fixtures;
using Polygon.Core.UnitTests.MockData;

namespace Polygon.Core.UnitTests.Services.Content
{
    [TestClass]
    public class TaxonomyServiceTests
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Category> _categoryRepository;
        private IRepository<Tag> _tagRepository;
        private ITaxonomyService _taxonomyService;
        
        [TestInitialize]
        public void Initialize()
        {
            var fixture = new InMemoryFixture();
            _unitOfWork = new UnitOfWork(fixture.Context);
            _categoryRepository = _unitOfWork.GetRepository<Category>();
            _tagRepository = _unitOfWork.GetRepository<Tag>();
            _taxonomyService = new TaxonomyService(_unitOfWork);
        }

        [TestMethod]
        public void Can_Create_Category()
        {
            var category = _taxonomyService.CreateCategory(MockTaxonomyData.SeedSingleCategory());
            
            Assert.IsNotNull(category);         
        }

        [TestMethod]
        public void Can_Update_Category()
        {
            const string categoryName = "Updated Category";
            var category = MockTaxonomyData.SeedSingleCategory();
            category.Name = categoryName;
            _categoryRepository.Add(category);

            var updatedCategory = _taxonomyService.UpdateCategory(category);
            
            Assert.AreEqual(updatedCategory.Name, categoryName);
        }

        [TestMethod]
        public void Can_Delete_Category()
        {
            var category = _categoryRepository.Add(MockTaxonomyData.SeedSingleCategory());
            _unitOfWork.Commit();

            var deletedItems = _taxonomyService.DeleteCategory(category);
            
            Assert.AreEqual(deletedItems, 1);
        }
    }
};