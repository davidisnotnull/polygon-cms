using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using Polygon.Core.Resources;
using Polygon.Core.Services.Interfaces.Content;
using System;
using System.Collections.Generic;

namespace Polygon.Core.Services.Content
{
    public class ReferenceDataService : BaseService, IReferenceDataService
    {
        private readonly IRepository<ReferenceCollection> _referenceCollectionRepository;
        private readonly IRepository<ReferenceItem> _referenceItemRepository;

        public ReferenceDataService(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {
            if (UnitOfWork == null)
                throw new NullReferenceException(ErrorMessages.UnitOfWorkNullReference);

            _referenceCollectionRepository = UnitOfWork.GetRepository<ReferenceCollection>();
            _referenceItemRepository = UnitOfWork.GetRepository<ReferenceItem>();
        }

        public IEnumerable<ReferenceCollection> GetAllReferenceCollections()
        {
            return _referenceCollectionRepository.GetAll();
        }

        public ReferenceCollection GetReferenceCollection(Guid id)
        {
            return _referenceCollectionRepository.GetById(id);
        }

        public IEnumerable<ReferenceItem> GetReferenceItemsByCollection(Guid id)
        {
            var referenceType = _referenceCollectionRepository.GetById(id);
            return GetReferenceItemsByCollection(referenceType);
        }

        public IEnumerable<ReferenceItem> GetReferenceItemsByCollection(ReferenceCollection referenceType)
        {
            return _referenceItemRepository.Get(r => r.ReferenceCollection == referenceType);
        }

        public ReferenceItem GetReferenceItem(Guid id)
        {
            return _referenceItemRepository.GetById(id);
        }

        public ReferenceCollection CreateReferenceCollection(ReferenceCollection referenceCollection)
        {
            _referenceCollectionRepository.Add(referenceCollection);
            UnitOfWork.Commit();
            return referenceCollection;
        }

        public ReferenceCollection UpdateReferenceCollection(ReferenceCollection referenceType)
        {
            _referenceCollectionRepository.Update(referenceType);
            UnitOfWork.Commit();
            return referenceType;
        }

        public ReferenceItem CreateReferenceItem(ReferenceItem referenceObject)
        {
            _referenceItemRepository.Add(referenceObject);
            UnitOfWork.Commit();
            return referenceObject;
        }

        public ReferenceItem UpdateReferenceItem(ReferenceItem referenceObject)
        {
            referenceObject.Modified = DateTime.Now;
            _referenceItemRepository.Update(referenceObject);
            UnitOfWork.Commit();
            return referenceObject;
        }

        public int DeleteReferenceItem(ReferenceItem referenceObject)
        {
            _referenceItemRepository.SoftDelete(referenceObject);
            return UnitOfWork.Commit();
        }

        public int DeleteReferenceItem(Guid id)
        {
            _referenceItemRepository.Delete(id);
            return UnitOfWork.Commit();
        }
    }
}
