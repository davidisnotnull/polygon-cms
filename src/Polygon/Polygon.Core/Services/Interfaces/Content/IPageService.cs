using System.Collections.Generic;
using Polygon.Core.Data.Entities.Pages;

namespace Polygon.Core.Services.Interfaces.Content
{
    public interface IPageService<T> where T : BasePage
    {
        public T CreatePage(T pageToCreate);

        public T UpdatePage(T pageToUpdate);

        public int DeletePage(T pageToDelete);

        public int DeletePage(int pageId);

        public T GetPageById(int id);

        public IEnumerable<T> GetAllPages();
    }
}
