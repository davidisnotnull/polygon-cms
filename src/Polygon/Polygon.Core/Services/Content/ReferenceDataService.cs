using Microsoft.Extensions.Logging;
using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using Polygon.Core.Services.Interfaces.Content;
using System.Collections.Generic;

namespace Polygon.Core.Services.Content
{
    public class ReferenceDataService : BaseService, IReferenceDataService
    {
        private readonly IRepository<ReferenceType> _referenceTypeRepository;
        private readonly IRepository<ReferenceObject> _referenceObjectRepository;

        public ReferenceDataService(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {
            _referenceTypeRepository = UnitOfWork.GetRepository<ReferenceType>();
            _referenceObjectRepository = UnitOfWork.GetRepository<ReferenceObject>();
        }

        public IEnumerable<ReferenceType> GetAllReferenceTypes()
        {
            return _referenceTypeRepository.GetAll();
        }

        public ReferenceType GetReferenceType(int id)
        {
            return _referenceTypeRepository.GetById(id);
        }

        public IEnumerable<ReferenceObject> GetReferenceObjectsByType(int id)
        {
            var referenceType = _referenceTypeRepository.GetById(id);
            return GetReferenceObjectsByType(referenceType);
        }

        public IEnumerable<ReferenceObject> GetReferenceObjectsByType(ReferenceType referenceType)
        {
            return _referenceObjectRepository.Get(r => r.ReferenceType == referenceType);
        }

        public ReferenceObject GetReferenceObject(int id)
        {
            return _referenceObjectRepository.GetById(id);
        }

        public ReferenceType CreateReferenceType(ReferenceType referenceType)
        {
            _referenceTypeRepository.Add(referenceType);
            UnitOfWork.Commit();
            return referenceType;
        }

        public ReferenceType UpdateReferenceType(ReferenceType referenceType)
        {
            _referenceTypeRepository.Update(referenceType);
            UnitOfWork.Commit();
            return referenceType;
        }

        public ReferenceObject CreateReferenceObject(ReferenceObject referenceObject)
        {
            _referenceObjectRepository.Add(referenceObject);
            UnitOfWork.Commit();
            return referenceObject;
        }

        public ReferenceObject UpdateReferenceObject(ReferenceObject referenceObject)
        {
            _referenceObjectRepository.Update(referenceObject);
            UnitOfWork.Commit();
            return referenceObject;
        }

        public int DeleteReferenceObject(ReferenceObject referenceObject)
        {
            _referenceObjectRepository.Delete(referenceObject);
            return UnitOfWork.Commit();
        }

        public int DeleteReferenceObject(int id)
        {
            _referenceObjectRepository.Delete(id);
            return UnitOfWork.Commit();
        }
    }
}
