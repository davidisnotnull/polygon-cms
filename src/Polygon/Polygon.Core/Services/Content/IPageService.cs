using Polygon.Core.Data.Entities.Pages;

namespace Polygon.Core.Services.Content
{
    public interface IPageService<T> where T : BasePage
    {
        public T CreatePage(T pageToCreate);

        public T UpdatePage(T pageToUpdate);

        public T DeletePage(T pageToDelete);

        public T GetPageById(int id);
    }
}
