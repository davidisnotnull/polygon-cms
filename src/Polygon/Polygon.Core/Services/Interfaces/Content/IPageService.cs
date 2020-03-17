using Polygon.Core.Data.Entities.Pages;
using System;
using System.Collections.Generic;

namespace Polygon.Core.Services.Interfaces.Content
{
    public interface IPageService<T> where T : BasePage
    {
        public T CreatePage(T pageToCreate);

        public T UpdatePage(T pageToUpdate);

        public int DeletePage(T pageToDelete);

        public int DeletePage(Guid pageId);

        public T GetPageById(Guid id);

        public IEnumerable<T> GetAllPages();

        public IEnumerable<T> GetAllPublishedPages();

        public int PublishPage(Guid id);

        public int PublishPage(T pageToPublish);

        public int UnpublishPage(Guid id);

        public int UnpublishPage(T pageToUnpublish);
    }
}
