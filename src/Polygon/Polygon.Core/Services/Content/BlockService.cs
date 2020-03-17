using Polygon.Core.Data.Entities.Blocks;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Data.Interfaces.Repositories;
using Polygon.Core.Resources;
using Polygon.Core.Services.Interfaces.Content;
using System;
using System.Collections.Generic;

namespace Polygon.Core.Services.Content
{
    public class BlockService<T> : BaseService, IBlockService<T> where T : BaseBlock
    {
        private readonly IRepository<T> _blockRepository;

        public BlockService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            if (UnitOfWork == null)
                throw new NullReferenceException(ErrorMessages.UnitOfWorkNullReference);

            _blockRepository = UnitOfWork.GetRepository<T>();
        }

        public T CreateBlock(T blockToCreate)
        {
            _blockRepository.Add(blockToCreate);
            UnitOfWork.Commit();
            return blockToCreate;
        }

        public int DeleteBlock(T blockToDelete)
        {
            _blockRepository.SoftDelete(blockToDelete);
            return UnitOfWork.Commit();
        }

        public int DeleteBlock(Guid blockId)
        {
            _blockRepository.SoftDelete(blockId);
            return UnitOfWork.Commit();
        }

        public IEnumerable<T> GetAllBlocks()
        {
            return _blockRepository.GetAvailable();
        }

        public int PublishBlock(Guid id)
        {
            var blockToPublish = _blockRepository.GetById(id);
            blockToPublish.IsPublished = true;
            _blockRepository.Update(blockToPublish);
            return UnitOfWork.Commit();
        }

        public int PublishBlock(T blockToPublish)
        {
            if (blockToPublish == null)
                return 0;

            blockToPublish.IsPublished = true;
            _blockRepository.Update(blockToPublish);
            return UnitOfWork.Commit();
        }

        public int UnpublishBlock(Guid id)
        {
            var blockToUnpublish = _blockRepository.GetById(id);
            blockToUnpublish.IsPublished = false;
            _blockRepository.Update(blockToUnpublish);
            return UnitOfWork.Commit();
        }

        public int UnpublishBlock(T blockToUnpublish)
        {
            if (blockToUnpublish == null)
                return 0;

            blockToUnpublish.IsPublished = false;
            _blockRepository.Update(blockToUnpublish);
            return UnitOfWork.Commit();
        }

        public T GetBlockById(Guid blockId)
        {
            return _blockRepository.GetById(blockId);
        }

        public T UpdateBlock(T blockToUpdate)
        {
            _blockRepository.Update(blockToUpdate);
            UnitOfWork.Commit();
            return blockToUpdate;
        }
    }
}
