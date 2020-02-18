using Polygon.Core.Data.Entities.Pages;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using Polygon.Core.Services.Interfaces.Content;
using System.Collections.Generic;

namespace Polygon.Core.Services.Content
{
    public class PageService<T> : BaseService, IPageService<T> where T : BasePage
    {
        private readonly IRepository<T> _pageRepository;

        public PageService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _pageRepository = UnitOfWork.GetRepository<T>();
        }

        public T CreatePage(T pageToCreate)
        {
            _pageRepository.Add(pageToCreate);
            UnitOfWork.Commit();
            return pageToCreate;
        }

        public T UpdatePage(T pageToUpdate)
        {
            _pageRepository.Update(pageToUpdate);
            UnitOfWork.Commit();
            return pageToUpdate;
        }

        public int DeletePage(T pageToDelete)
        {
            _pageRepository.SoftDelete(pageToDelete);
            return UnitOfWork.Commit();
        }

        public int DeletePage(int pageId)
        {
            _pageRepository.SoftDelete(pageId);
            return UnitOfWork.Commit();
        }

        public T GetPageById(int id)
        {
            return _pageRepository.GetById(id);
        }

        public IEnumerable<T> GetAllPages()
        {
            return _pageRepository.GetAll();
        }
    }
}
