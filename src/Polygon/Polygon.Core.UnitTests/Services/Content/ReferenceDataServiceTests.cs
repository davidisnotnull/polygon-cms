using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polygon.Core.Data;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using Polygon.Core.Services.Content;
using Polygon.Core.Services.Interfaces.Content;
using Polygon.Core.UnitTests.Fixtures;
using Polygon.Core.UnitTests.MockData;
using System;
using System.Linq;
using Polygon.Core.UnitTests.Helpers;

namespace Polygon.Core.UnitTests.Services.Content
{
    [TestClass]
    public class ReferenceDataServiceTests
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<ReferenceCollection> _referenceCollectionRepository;
        private IRepository<ReferenceItem> _referenceItemRepository;
        private IReferenceDataService _referenceDataService;

        [TestInitialize]
        public void Initialize()
        {
            var fixture = new InMemoryFixture();
            _unitOfWork = new UnitOfWork(fixture.Context);
            _referenceCollectionRepository = _unitOfWork.GetRepository<ReferenceCollection>();
            _referenceItemRepository = _unitOfWork.GetRepository<ReferenceItem>();
            _referenceDataService = new ReferenceDataService(_unitOfWork);
        }

        [TestMethod]
        public void Can_Get_All_ReferenceTypes()
        {
            var mockReferenceTypes = MockReferenceData.SeedMultipleReferenceCollections();
            _referenceCollectionRepository.Add(mockReferenceTypes);
            _unitOfWork.Commit();

            Assert.AreEqual(mockReferenceTypes.Length, _referenceDataService.GetAllReferenceCollections().Count());
        }

        [TestMethod]
        public void Can_Get_ReferenceType()
        {
            var mockReferenceTypes = MockReferenceData.SeedMultipleReferenceCollections();
            _referenceCollectionRepository.Add(mockReferenceTypes);

            var random = new Random();
            var referenceCollectionGuidSelector = random.Next(1, mockReferenceTypes.Length);
            var referenceCollectionId = GuidSequenceHelper.GetGuid(referenceCollectionGuidSelector);

            var referenceCollection = _referenceDataService.GetReferenceCollection(referenceCollectionId);

            Assert.IsNotNull(referenceCollection);
        }

        [TestMethod]
        public void Can_Create_ReferenceType()
        {
            var referenceCollection = _referenceDataService.CreateReferenceCollection(MockReferenceData.SeedSingleReferenceCollection());
            Assert.IsNotNull(referenceCollection.Id);
        }

        [TestMethod]
        public void Can_Update_ReferenceType()
        {
            var mockReferenceTypes = MockReferenceData.SeedMultipleReferenceCollections();
            _referenceCollectionRepository.Add(mockReferenceTypes);

            var random = new Random();
            var referenceCollectionGuidSelector = random.Next(1, mockReferenceTypes.Length);
            var referenceCollectionId = GuidSequenceHelper.GetGuid(referenceCollectionGuidSelector);

            var referenceCollection = _referenceCollectionRepository.GetById(referenceCollectionId);
            const string referenceTypeName = "Updated Reference Type Name";
            referenceCollection.Name = referenceTypeName;

            var updatedReferenceCollection = _referenceDataService.UpdateReferenceCollection(referenceCollection);

            Assert.AreEqual(referenceTypeName, updatedReferenceCollection.Name);
        }

        [TestMethod]
        public void Can_Get_ReferenceObject()
        {
            var referenceCollection = _referenceCollectionRepository.Add(MockReferenceData.SeedSingleReferenceCollection());
            var referenceItem = _referenceItemRepository.Add(new ReferenceItem() { Name = "Test Reference Object", ReferenceCollection = referenceCollection});

            Assert.IsNotNull(_referenceDataService.GetReferenceItem(referenceItem.Id));
        }

        [TestMethod]
        public void Can_Create_ReferenceObject()
        {
            var referenceCollection = _referenceCollectionRepository.Add(MockReferenceData.SeedSingleReferenceCollection());

            var referenceItem = new ReferenceItem()
            {
                Name = "Test Reference Object",
                ReferenceCollection = referenceCollection
            };

            Assert.IsNotNull(_referenceDataService.CreateReferenceItem(referenceItem));
        }

        [TestMethod]
        public void Can_Update_ReferenceObject()
        {
            var referenceCollection = _referenceCollectionRepository.Add(MockReferenceData.SeedSingleReferenceCollection());
            var referenceItem = _referenceItemRepository.Add(new ReferenceItem() { Name = "Test Reference Item", ReferenceCollection = referenceCollection });

            const string referenceObjectName = "Update Name Test";
            referenceItem.Name = referenceObjectName;

            var updatedReferenceItem = _referenceDataService.UpdateReferenceItem(referenceItem);

            Assert.AreEqual(referenceObjectName, updatedReferenceItem.Name);
        }

        [TestMethod]
        public void Can_Delete_ReferenceObject()
        {
            var referenceCollection = _referenceCollectionRepository.Add(MockReferenceData.SeedSingleReferenceCollection());
            var referenceItem = _referenceItemRepository.Add(MockReferenceData.SeedSingleReferenceItem(referenceCollection));

            Assert.AreEqual(1, _referenceDataService.DeleteReferenceItem(referenceItem));
        }
    }
}