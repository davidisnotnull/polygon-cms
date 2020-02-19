using Polygon.Core.Data.Entities.Blocks;
using System.Collections.Generic;

namespace Polygon.Core.Services.Interfaces.Content
{
    public interface IBlockService<T> where T : BaseBlock
    {
        public T CreateBlock(T blockToCreate);

        public T UpdateBlock(T blockToUpdate);

        public int DeleteBlock(T blockToDelete);

        public int DeleteBlock(int blockId);

        public T GetBlockById(int blockId);

        public IEnumerable<T> GetAllBlocks();

        public int PublishBlock(int id);

        public int PublishBlock(T blockToPublish);

        public int UnpublishBlock(int id);

        public int UnpublishBlock(T blockToUnpublish);
    }
}
