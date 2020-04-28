using Microsoft.Extensions.Logging;
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
    /// <summary>
    /// Creates tabular datasets to be consumed by the TesseractTable typescript library
    /// </summary>
    /// <remarks>
    /// When creating the tableRow array, make sure that the guid of the item that you want to interact with in the row is always at
    /// position 0 in the array. Otherwise it won't work with the TesseractTable typescript library.
    /// </remarks>
    public class TableService : BaseService, ITableService
    {
        private readonly ILogger<TableService> _logger;

        public TableService(ILogger<TableService> logger, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _logger = logger;
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
                ColumnCount = 2,
                TotalNumberOfRows = referenceCollections.Count()
            };
        }

        public TableModel BuildReferenceItemTable(Guid guid)
        {
            var repository = UnitOfWork.GetRepository<ReferenceItem>();
            var referenceItems = repository.GetAvailable()
                .Where(x => x.ReferenceCollectionId == guid).ToList();

            var tableRows = new List<string[]>();

            foreach (var item in referenceItems)
            {
                var row = new[]
                {
                    item.Id.ToString(),
                    item.Name
                };

                tableRows.Add(row);
            }
            
            return new TableModel
            {
                Header = new List<string>
                {
                    "Name"
                },
                Rows = tableRows,
                ColumnCount = 1,
                TotalNumberOfRows = referenceItems.Count()
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
