using System;
using Polygon.Core.Data.Entities;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.Core.Services.Content
{
    public class ContentService<TContent> : BaseService, IContentService<TContent> where TContent : BaseEntity
    {
        public ContentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

        public dynamic Get(string guid)
        {
            var repository = UnitOfWork.GetRepository<TContent>();
            return repository.GetById(Guid.Parse(guid));
        }
    }
}