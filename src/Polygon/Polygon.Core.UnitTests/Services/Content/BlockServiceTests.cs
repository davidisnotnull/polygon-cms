using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polygon.Core.Data;
using Polygon.Core.Data.Entities.Blocks;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using Polygon.Core.Services.Content;
using Polygon.Core.Services.Interfaces.Content;
using Polygon.Core.UnitTests.Fixtures;
using Polygon.Core.UnitTests.MockData;
using System;
using System.Linq;
using Polygon.Core.UnitTests.Helpers;

namespace Polygon.Core.UnitTests.Services.Content
{
    [TestClass]
    public class BlockServiceTests
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<TeaserBlock> _blockRepository;
        private IBlockService<TeaserBlock> _blockService;

        [TestInitialize]
        public void Initialize()
        {
            var fixture = new InMemoryFixture();
            _unitOfWork = new UnitOfWork(fixture.Context);
            _blockRepository = _unitOfWork.GetRepository<TeaserBlock>();
            _blockService = new BlockService<TeaserBlock>(_unitOfWork);
        }

        [TestMethod]
        public void Can_Create_Block()
        {
            var createdBlock = _blockService.CreateBlock(MockBlocks.SeedSingleTeaserBlock());
            Assert.IsNotNull(createdBlock.Id);
        }

        [TestMethod]
        public void Can_Update_Block()
        {
            var mockTeaserBlocks = MockBlocks.SeedMultipleTeaserBlocks();
            _blockRepository.Add(mockTeaserBlocks);
            var random = new Random();
            var blockGuidSelector = random.Next(1, mockTeaserBlocks.Length);
            var blockId = GuidSequenceHelper.GetGuid(blockGuidSelector);

            var block = _blockRepository.GetById(blockId);
            const string updatedBlockName = "Updated Block Name";
            block.Name = updatedBlockName;

            var updatedBlock = _blockService.UpdateBlock(block);

            Assert.AreEqual(updatedBlockName, updatedBlock.Name);
        }

        [TestMethod]
        public void Can_Delete_Block_With_Entity()
        {
            var block = _blockRepository.Add(MockBlocks.SeedSingleTeaserBlock());
            _unitOfWork.Commit();

            _blockService.DeleteBlock(block);
            var deletedBlock = _blockRepository.GetById(block.Id);

            Assert.AreEqual(true, deletedBlock.IsDeleted);            
        }

        [TestMethod]
        public void Can_Delete_Block_With_Id()
        {
            var block = _blockRepository.Add(MockBlocks.SeedSingleTeaserBlock());
            _blockService.DeleteBlock(block.Id);

            var deletedBlock = _blockRepository.GetById(block.Id);
            Assert.AreEqual(true, deletedBlock.IsDeleted);
        }

        [TestMethod]
        public void Can_Get_Block_By_Id()
        {
            var block = _blockRepository.Add(MockBlocks.SeedSingleTeaserBlock());
            Assert.IsNotNull(_blockService.GetBlockById(block.Id));
        }

        [TestMethod]
        public void Can_Get_All_Blocks()
        {
            var blocks = MockBlocks.SeedMultipleTeaserBlocks();
            _blockRepository.Add(blocks);
            _unitOfWork.Commit();

            var returnedBlocks = _blockService.GetAllBlocks();
            Assert.AreEqual(blocks.Length, returnedBlocks.Count());
        }

        [TestMethod]
        public void Can_Publish_Block_By_Entity()
        {
            var block = _blockRepository.Add(MockBlocks.SeedSingleTeaserBlock());
            _unitOfWork.Commit();

            _blockService.PublishBlock(block);

            var publishedBlock = _blockService.GetBlockById(block.Id);

            Assert.AreEqual(true, publishedBlock.IsPublished);
        }

        [TestMethod]
        public void Can_Publish_Page_By_Id()
        {
            var block = _blockRepository.Add(MockBlocks.SeedSingleTeaserBlock());
            _unitOfWork.Commit();

            _blockService.PublishBlock(block.Id);

            var publishedBlock = _blockService.GetBlockById(block.Id);

            Assert.AreEqual(true, publishedBlock.IsPublished);
        }

        [TestMethod]
        public void Can_Unpublish_Page_By_Entity()
        {
            var block = MockBlocks.SeedSingleTeaserBlock();
            block.IsPublished = true;
            _blockRepository.Add(block);
            _unitOfWork.Commit();

            _blockService.UnpublishBlock(block);

            var unpublishedBlock = _blockService.GetBlockById(block.Id);

            Assert.AreEqual(false, unpublishedBlock.IsPublished);
        }

        [TestMethod]
        public void Can_Unpublish_Page_By_Id()
        {
            var block = MockBlocks.SeedSingleTeaserBlock();
            block.IsPublished = true;
            _blockRepository.Add(block);
            _unitOfWork.Commit();

            _blockService.UnpublishBlock(block.Id);

            var unpublishedBlock = _blockService.GetBlockById(block.Id);

            Assert.AreEqual(false, unpublishedBlock.IsPublished);
        }
    }
}
