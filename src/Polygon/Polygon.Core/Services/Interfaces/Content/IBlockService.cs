using Polygon.Core.Data.Entities.Blocks;
using System;
using System.Collections.Generic;

namespace Polygon.Core.Services.Interfaces.Content
{
    public interface IBlockService<T> where T : BaseBlock
    {
        public T CreateBlock(T blockToCreate);

        public T UpdateBlock(T blockToUpdate);

        public int DeleteBlock(T blockToDelete);

        public int DeleteBlock(Guid blockId);

        public T GetBlockById(Guid blockId);

        public IEnumerable<T> GetAllBlocks();

        public int PublishBlock(Guid id);

        public int PublishBlock(T blockToPublish);

        public int UnpublishBlock(Guid id);

        public int UnpublishBlock(T blockToUnpublish);
    }
}
