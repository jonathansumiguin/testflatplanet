using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TestFlatPlanet.Facade;

namespace TestFlatPlanet.Controllers.Api
{
    [System.Web.Http.RoutePrefix("api/counter")]
    public class CounterApiController : ApiController
    {
        private readonly CounterFacade _counterFacade;
        public CounterApiController()
        {
            _counterFacade = new CounterFacade();
        }

        [HttpGet]
        [Route("getcount")]
        public IHttpActionResult GetCount()
        {
            var count = _counterFacade.GetCount();

            return Json(new { count = count });
        }

        [HttpPost]
        [Route("updatecount/")]
        public IHttpActionResult UpdateCount()
        {
            var isUpdated = _counterFacade.UpdateCount();

            return Json(new { isUpdated = isUpdated });
        }
    }
}
