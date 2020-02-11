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

namespace Polygon.Core.UnitTests.Services.Content
{
    [TestClass]
    public class ReferenceDataServiceTests
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<ReferenceType> _referenceTypeRepository;
        private IRepository<ReferenceObject> _referenceObjectRepository;
        private IReferenceDataService _referenceDataService;

        [TestInitialize]
        public void Initialize()
        {
            var fixture = new InMemoryFixture();
            _unitOfWork = new UnitOfWork(fixture.Context);
            _referenceTypeRepository = _unitOfWork.GetRepository<ReferenceType>();
            _referenceObjectRepository = _unitOfWork.GetRepository<ReferenceObject>();
            _referenceDataService = new ReferenceDataService(_unitOfWork);
        }

        [TestMethod]
        public void Can_Get_All_ReferenceTypes()
        {
            var mockReferenceTypes = MockReferenceData.SeedMultipleReferenceTypes();
            _referenceTypeRepository.Add(mockReferenceTypes);
            _unitOfWork.Commit();

            Assert.AreEqual(_referenceDataService.GetAllReferenceTypes().Count(), mockReferenceTypes.Length);
        }

        [TestMethod]
        public void Can_Get_ReferenceType()
        {
            var mockReferenceTypes = MockReferenceData.SeedMultipleReferenceTypes();
            _referenceTypeRepository.Add(mockReferenceTypes);

            var random = new Random();
            var referenceTypeId = random.Next(1, mockReferenceTypes.Length);

            var referenceType = _referenceDataService.GetReferenceType(referenceTypeId);

            Assert.IsNotNull(referenceType);
        }

        [TestMethod]
        public void Can_Create_ReferenceType()
        {
            var referenceType = _referenceDataService.CreateReferenceType(MockReferenceData.SeedSingleReferenceType());
            Assert.IsNotNull(referenceType.Id);
        }

        [TestMethod]
        public void Can_Update_ReferenceType()
        {
            var mockReferenceTypes = MockReferenceData.SeedMultipleReferenceTypes();
            _referenceTypeRepository.Add(mockReferenceTypes);

            var random = new Random();
            var referenceTypeId = random.Next(1, mockReferenceTypes.Length);

            var referenceType = _referenceTypeRepository.GetById(referenceTypeId);
            referenceType.Name = "Updated Reference Type Name";

            var updatedReferenceType = _referenceDataService.UpdateReferenceType(referenceType);

            Assert.AreEqual(updatedReferenceType.Name, "Updated Reference Type Name");
        }

        [TestMethod]
        public void Can_Get_ReferenceObject()
        {
            var referenceType = _referenceTypeRepository.Add(MockReferenceData.SeedSingleReferenceType());
            var referenceObject = _referenceObjectRepository.Add(new ReferenceObject() { Name = "Test Reference Object", ReferenceType = referenceType});

            Assert.IsNotNull(_referenceDataService.GetReferenceObject(referenceObject.Id));
        }

        [TestMethod]
        public void Can_Create_ReferenceObject()
        {
            var referenceType = _referenceTypeRepository.Add(MockReferenceData.SeedSingleReferenceType());

            var referenceObject = new ReferenceObject()
            {
                Name = "Test Reference Object",
                ReferenceType = referenceType
            };

            Assert.IsNotNull(_referenceDataService.CreateReferenceObject(referenceObject));
        }

        [TestMethod]
        public void Can_Update_ReferenceObject()
        {
            var referenceType = _referenceTypeRepository.Add(MockReferenceData.SeedSingleReferenceType());
            var referenceObject = _referenceObjectRepository.Add(new ReferenceObject() { Name = "Test Reference Object", ReferenceType = referenceType });

            const string referenceObjectName = "Update Name Test";
            referenceObject.Name = referenceObjectName;

            var updatedReferenceObject = _referenceDataService.UpdateReferenceObject(referenceObject);

            Assert.AreEqual(updatedReferenceObject.Name, referenceObjectName);
        }

        [TestMethod]
        public void Can_Delete_ReferenceObject()
        {
            var referenceType = _referenceTypeRepository.Add(MockReferenceData.SeedSingleReferenceType());
            var referenceObject = _referenceObjectRepository.Add(MockReferenceData.SeedSingleReferenceObject(referenceType));

            Assert.AreEqual(_referenceDataService.DeleteReferenceObject(referenceObject), 1);
        }
    }
}