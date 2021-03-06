﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Polygon.Core.Services.Interfaces.Tesseract;
using System;
using System.Net;

namespace Polygon.CMS.Controllers.Tesseract
{
    [ApiController]
    [Route("api/tesseract/[controller]")]
    public class TableApiController : ControllerBase
    {
        private readonly ILogger<TableApiController> _logger;
        private ITableService _tableService;

        public TableApiController(ILogger<TableApiController> logger, ITableService tableService)
        {
            _logger = logger;
            _tableService = tableService;
        }
        
        [HttpPost]
        [Route("GetReferenceCollections")]
        public IActionResult GetReferenceCollections(int pageSize)
        {
            try
            {
                var tableModel = _tableService.BuildReferenceCollectionTable(pageSize);
                return new JsonResult(tableModel);
            }
            catch (WebException exception)
            {
                throw new WebException($"API request failed with the message - {exception.InnerException}");
            }
        }

        [HttpPost]
        [Route("GetReferenceItems")]
        public JsonResult GetReferenceItems(string guid)
        {
            var id = Guid.Parse(guid);
            try
            {
                var tableModel = _tableService.BuildReferenceItemTable(id);
                return new JsonResult(tableModel);
            }
            catch (WebException exception)
            {
                throw new WebException($"API request failed with the message - {exception.InnerException}");
            }
        }
    }
}