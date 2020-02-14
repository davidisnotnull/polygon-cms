using Polygon.Core.Data.Entities.Pages;
using Polygon.Core.Data.Entities.Taxonomy;

namespace Polygon.Core.Services.Interfaces.Content
{
    public interface ITaxonomyService
    {
        public Category CreateCategory(Category category);

        public Category UpdateCategory(Category category);

        public int DeleteCategory(Category category);

        public int DeleteCategory(int id);

        public Tag CreateTag(string name);

        public Tag UpdateTag(Tag tag);

        public int DeleteTag(Tag tag);

        public int DeleteTag(int id);

        public BasePage GetAllPagesOfCategory(Category category);

        public BasePage GetAllPagesOfCategory(int id);

        public BasePage GetAllPagesWithTag(Tag tag);

        public BasePage GetAllPagesWithTag(int id);
    }
}
