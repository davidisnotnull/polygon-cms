using Polygon.Core.Data.Entities.Pages;
using Polygon.Core.Data.Entities.Taxonomy;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using Polygon.Core.Resources;
using Polygon.Core.Services.Interfaces.Content;
using System;

namespace Polygon.Core.Services.Content
{
    public class TaxonomyService : BaseService, ITaxonomyService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly IRepository<BasePage> _pageRepository;

        public TaxonomyService(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            if (UnitOfWork == null)
                throw new NullReferenceException(ErrorMessages.UnitOfWorkNullReference);

            _categoryRepository = UnitOfWork.GetRepository<Category>();
            _tagRepository = UnitOfWork.GetRepository<Tag>();
            _pageRepository = UnitOfWork.GetRepository<BasePage>();
        }

        public Category CreateCategory(Category category)
        {
            _categoryRepository.Add(category);
            UnitOfWork.Commit();
            return category;
        }

        public Tag CreateTag(string name)
        {
            var tag = new Tag
            {
                Name = name
            };

            _tagRepository.Add(tag);
            UnitOfWork.Commit();
            return tag;
        }

        public int DeleteCategory(Category category)
        {
            _categoryRepository.Delete(category);
            return UnitOfWork.Commit();
        }

        public int DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
            return UnitOfWork.Commit();
        }

        public int DeleteTag(Tag tag)
        {
            _tagRepository.Delete(tag);
            return UnitOfWork.Commit();
        }

        public int DeleteTag(int id)
        {
            _tagRepository.Delete(id);
            return UnitOfWork.Commit();
        }

        public BasePage GetAllPagesOfCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public BasePage GetAllPagesOfCategory(int id)
        {
            throw new NotImplementedException();
        }

        public BasePage GetAllPagesWithTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public BasePage GetAllPagesWithTag(int id)
        {
            throw new NotImplementedException();
        }

        public Category UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
            UnitOfWork.Commit();
            return category;
        }

        public Tag UpdateTag(Tag tag)
        {
            _tagRepository.Update(tag);
            UnitOfWork.Commit();
            return tag;
        }
    }
}
