using MyVehicleRepairServiceNeeds.Models;
using MyVehicleRepairServiceNeeds.Services.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WikiWebStarter.Web.Models.Responses;

namespace MyVehicleRepairServiceNeeds.TowApp.Web.Controllers.API
{

    [RoutePrefix("api/towinfo")]
    public class TowServicesAPIController : ApiController
    {

        private ITowInfoService _towInfoService;

        public TowServicesAPIController(ITowInfoService towInfoService)
        {
            _towInfoService = towInfoService;
        }

        [Route("towrecord"), HttpPost()]
        public HttpResponseMessage PostTowInfo(TowInfoAddRequest model)
        {

            HttpStatusCode code = HttpStatusCode.OK;
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = _towInfoService.CreateTowRecord(model);

            if (response.Item == 0)
            {
                code = HttpStatusCode.BadRequest;
                response.IsSuccessful = false;
            }
            return Request.CreateResponse(code, response);
        }
    }
}
