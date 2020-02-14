using System;
using System.Collections.Generic;
using System.Text;
using Polygon.Core.Data.Entities.Blocks;

namespace Polygon.Core.Services.Content
{
    public interface IBlockService<T> where T : BaseBlock
    {
        public T CreateBlock(T blockToCreate);

        public T UpdateBlock(T blockToUpdate);

        public int DeleteBlock(T blockToDelete);

        public int DeleteBlock(int blockId);

        public T GetBlockById(int blockId);
    }
}
