using Polygon.Core.Data.Entities.ReferenceData;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Helpers;
using Polygon.Core.Models.Tesseract;
using Polygon.Core.Services.Interfaces.Tesseract;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Polygon.Core.Services.Tesseract
{
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
                    item.Name,
                    item.Description,
                    $"<a href=\"ReferenceData/Details/?guid={item.Id.ToString()}\">Details</a>",
                    $"<a href=\"ReferenceData/UpdateReferenceCollection/?guid={item.Id.ToString()}\" class=\"tesseract__modal\"" +
                    "data-size=\"medium\" data-toggle=\"modal\">Edit</a>"
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
                    item.Name,
                    $"<a href=\"ReferenceTypes/ManageReferenceItem/?guid={item.Id.ToString()}\" class=\"tesseract__modal\"" +
                    $"data-size=\"medium\" data-toggle\"modal\">Edit</a>",
                    $"<a href=\"ReferenceTypes/DeleteReferenceItem/?guid={item.Id.ToString()}\" class=\"tesseract__modal\"" +
                    "data-size=\"medium\" data-toggle=\"modal\">Delete</a>"
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
                ColumnCount = 4,
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
