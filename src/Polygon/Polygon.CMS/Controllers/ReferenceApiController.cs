using System;
using Microsoft.AspNetCore.Mvc;
using Polygon.Core.Services.Interfaces.Content;

namespace Polygon.CMS.Controllers
{
    [Route("api/[controller]")]
    public class ReferenceApiController : Controller
    {
        private readonly IReferenceDataService _referenceDataService;

        public ReferenceApiController(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }

        [HttpPost]
        public IActionResult GetReferenceObjects(string id)
        {
            var referenceObjects = _referenceDataService.GetReferenceItemsByCollection(Guid.Parse(id));
            return new JsonResult(referenceObjects);
        }
    }
}