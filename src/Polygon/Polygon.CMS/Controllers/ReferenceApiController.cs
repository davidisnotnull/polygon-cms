using System;
using Microsoft.AspNetCore.Mvc;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceApiController : ControllerBase
    {
        private readonly IReferenceDataService _referenceDataService;

        public ReferenceApiController(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }

        public IActionResult GetReferenceObjects(string id)
        {
            var guid = Guid.Parse(id);
            var referenceObjects = _referenceDataService.GetReferenceItemsByCollection(guid);
            return new JsonResult(referenceObjects);
        }
    }
}