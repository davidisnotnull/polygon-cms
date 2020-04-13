using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polygon.Core.Data;
using Polygon.Core.Data.Entities.Pages;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using Polygon.Core.Services.Content;
using Polygon.Core.Services.Interfaces.Content;
using Polygon.Core.UnitTests.Fixtures;
using Polygon.Core.UnitTests.Helpers;
using Polygon.Core.UnitTests.MockData;
using System;
using System.Linq;

namespace Polygon.Core.UnitTests.Services.Content
{
    [TestClass]
    public class PageServiceTests
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<StandardPage> _pageRepository;
        private IPageService<StandardPage> _pageService;

        [TestInitialize]
        public void Initialize()
        {
            var fixture = new InMemoryFixture();
            _unitOfWork = new UnitOfWork(fixture.Context);
            _pageRepository = _unitOfWork.GetRepository<StandardPage>();
            _pageService = new PageService<StandardPage>(_unitOfWork);
        }

        [TestMethod]
        public void Can_Create_Page()
        {
            var createdPage = _pageService.CreatePage(MockPages.SeedSinglePage());
            Assert.IsNotNull(createdPage.Id);
        }

        [TestMethod]
        public void Can_Update_Page()
        {
            var mockStandardPages = MockPages.SeedMultipleStandardPages();
            _pageRepository.Add(mockStandardPages);
            _unitOfWork.Commit();
            
            var random = new Random();
            var pageGuidSelector = random.Next(1, mockStandardPages.Length);
            var pageId = GuidSequenceHelper.GetGuid(pageGuidSelector);

            var page = _pageRepository.GetById(pageId);
            const string updatedHeading = "Updating the page name";
            page.Name = updatedHeading;

            var updatedPage = _pageService.UpdatePage(page);

            Assert.AreEqual(updatedHeading, updatedPage.Name);
        }

        [TestMethod]
        public void Can_Delete_Page()
        {
            var page = _pageRepository.Add(MockPages.SeedSinglePage());
            _pageService.DeletePage(page);

            var deletedPage = _pageService.GetPageById(page.Id);

            Assert.AreEqual(true, deletedPage.IsDeleted);
        }

        [TestMethod]
        public void Can_Get_Page_By_Id()
        {
            var page = _pageRepository.Add(MockPages.SeedSinglePage());
            Assert.IsNotNull(_pageService.GetPageById(page.Id));
        }

        [TestMethod]
        public void Can_Get_All_Pages()
        {
            var pages = MockPages.SeedMultipleStandardPages();
            _pageRepository.Add(pages);
            _unitOfWork.Commit();

            var returnedPages = _pageService.GetAllPages();
            Assert.AreEqual(pages.Length, returnedPages.Count());
        }

        [TestMethod]
        public void Can_Publish_Page_By_Entity()
        {
            var page = MockPages.SeedSinglePage();

            _pageRepository.Add(page);
            _unitOfWork.Commit();

            _pageService.PublishPage(page);

            var publishedPage = _pageService.GetPageById(page.Id);

            Assert.AreEqual(true, publishedPage.IsPublished);
        }

        [TestMethod]
        public void Can_Publish_Page_By_Id()
        {
            var page = MockPages.SeedSinglePage();
            _pageRepository.Add(page);
            _unitOfWork.Commit();

            _pageService.PublishPage(page.Id);

            var publishedPage = _pageService.GetPageById(page.Id);

            Assert.AreEqual(true, publishedPage.IsPublished);
        }

        [TestMethod]
        public void Can_Unpublish_Page_By_Entity()
        {
            var page = MockPages.SeedSinglePage();
            page.IsPublished = true;
            _pageRepository.Add(page);
            _unitOfWork.Commit();

            _pageService.UnpublishPage(page);

            var unpublishedPage = _pageService.GetPageById(page.Id);

            Assert.AreEqual(false, unpublishedPage.IsPublished);
        }

        [TestMethod]
        public void Can_Unpublish_Page_By_Id()
        {
            var page = MockPages.SeedSinglePage();
            page.IsPublished = true;
            _pageRepository.Add(page);
            _unitOfWork.Commit();

            _pageService.UnpublishPage(page.Id);

            var unpublishedPage = _pageService.GetPageById(page.Id);

            Assert.AreEqual(false, unpublishedPage.IsPublished);
        }

    }
}
