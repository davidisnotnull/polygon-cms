using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Helpers;
using Polygon.Core.Models.Tesseract;
using Polygon.Core.Services.Interfaces.Tesseract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Polygon.Core.Services.Tesseract
{
    public class TableService : BaseService, ITableService
    {
        public TableService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

        public TableModel BuildReferenceCollectionTable(int pager)
        {
            var repository = UnitOfWork.GetRepository<ReferenceCollection>();
            var referenceCollections = repository.GetAvailable().ToList();

            var tableRows = new List<string[]>();
            
            foreach (var item in referenceCollections)
            {
                var tableRow = new[]
                {
                    item.Id.ToString(),
                    item.Name,
                    item.Description
                };

                tableRows.Add(tableRow);
            }

            return new TableModel
            {
                Header = new List<string>
                {
                    "Name",
                    "Description"
                },
                Rows = tableRows,
                ColumnCount = 5,
                TotalNumberOfRows = referenceCollections.Count()
            };
        }
        
        public TableModel BuildTableModel(Guid id, int pager)
        {
            var contentType = ContentHelper.GetTypeByGuid(id.ToString());
            var instance = ContentHelper.ConvertTypeToClass(contentType);

            var tableModel = new TableModel();

            switch (instance)
            {
                case ReferenceCollection referenceCollection:
                    var repository = UnitOfWork.GetRepository<ReferenceCollection>();
                    var referenceCollections = repository.GetAvailable();
                    
                    return tableModel;
                default:
                    return null;
            }
        }
    }
}
