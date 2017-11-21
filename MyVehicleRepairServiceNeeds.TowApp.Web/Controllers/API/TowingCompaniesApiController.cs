using MyVehicleRepairServiceNeeds.Models;
using MyVehicleRepairServiceNeeds.Services.cs;
using MyVehicleRepairServiceNeeds.TowApp.Web.Domain;
using MyVehicleRepairServiceNeeds.TowApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WikiWebStarter.Web.Models.Responses;

namespace MyVehicleRepairServiceNeeds.TowApp.Web.Controllers.API
{

    [RoutePrefix("api/towing/companies")]
    public class TowingCompaniesApiController : ApiController
    {

        private ITowInfoService _towInfoService;

        public TowingCompaniesApiController(ITowInfoService towInfoService)
        {
            _towInfoService = towInfoService;
        }

        [Route(), HttpPost]
        public HttpResponseMessage AddTowInfo(TowInfoAddRequest model)
        {

            HttpStatusCode code = HttpStatusCode.OK;
            ItemResponse<int> response = new ItemResponse<int>();


            if (!ModelState.IsValid)
            {
                code = HttpStatusCode.BadRequest;
                return Request.CreateErrorResponse(code, ModelState);
            }
            else
            {
                response.Item = _towInfoService.Add(model);
            }
      
            return Request.CreateResponse(code, response);
        }
        [Route(), HttpGet]
        public HttpResponseMessage GetTowInfo()
        {

            HttpStatusCode code = HttpStatusCode.OK;
            ItemsResponse<TowInfo> response = new ItemsResponse<TowInfo>();
            response.Items = _towInfoService.Get();

            if (response.Items == null)
            {
                code = HttpStatusCode.BadRequest;
                response.IsSuccessful = false;
            }
            return Request.CreateResponse(code, response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateTowRecord(TowInfoUpdateRequest model, int id)
        {

            HttpStatusCode code = HttpStatusCode.OK;
            SuccessResponse response = new SuccessResponse();


            if (!ModelState.IsValid)
            {
                code = HttpStatusCode.BadRequest;
                return Request.CreateErrorResponse(code, ModelState);
            }
            _towInfoService.Update(model, id);
            return Request.CreateResponse(code, response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteTowRecord(int id)
        {
            SuccessResponse response = new SuccessResponse();
            HttpStatusCode code = HttpStatusCode.OK;

            if (!ModelState.IsValid)
            {
                code = HttpStatusCode.BadRequest;
                return Request.CreateErrorResponse(code, ModelState);
            }
            _towInfoService.Delete(id);
            return Request.CreateResponse(code, response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetTowInfoById(int id)
        {
            HttpStatusCode code = HttpStatusCode.OK;

            ItemResponse<TowInfo> response = new ItemResponse<TowInfo>();

            response.Item = _towInfoService.Get(id);

            if (response.Item == null)
            {
                code = HttpStatusCode.NotFound;
                response.IsSuccessful = false;
            }

            return Request.CreateResponse(code, response);
        }
    }
}
