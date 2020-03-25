using System;
using System.ComponentModel;
using Polygon.Core.Models.Tesseract;

namespace Polygon.Core.Services.Interfaces.Tesseract
{
    public interface ITableService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        TableModel BuildReferenceCollectionTable(int pager);

        /// <summary>
        /// Builds out a TableModel to use to render a table in the front end
        /// </summary>
        /// <param name="id">Guid of the ContentType to load into the table</param>
        /// <param name="pager">Number of items per page</param>
        /// <returns>A populated TableModel</returns>
        /// <remarks>This is experimental. Do not use.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TableModel BuildTableModel(Guid id, int pager);
    }
}
