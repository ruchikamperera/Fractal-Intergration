using Aliencube.AzureFunctions.Extensions.OpenApi.Core.Attributes;
using Application.PickList.Commands.AddPickList;
using Application.PickList.Commands.GetPickList;
using Domain.Entities;
using FunctionApi.Extension;
using FunctionApi.Validators.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace FunctionApi.Controllers
{
    [ApiExplorerSettings(GroupName = "PickList")]

    public class PickListController : ApiController
    {
        private const string Type = "PickList";
        public PickListController(ILogger<ApiController> logger, IHttpContextAccessor httpContextAccessor) : base(logger, httpContextAccessor)
        {
        }
        [OpenApiOperation("PickList", "PickList")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Picklist))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //[QueryStringParameter("PageNumber", "", DataType = typeof(string), Required = false)]
       // [QueryStringParameter("PageSize", "", DataType = typeof(string), Required = false)]
        [FunctionName("GetPickLists")]
        public async Task<IActionResult> PickLists(

            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "PickList/{type}")]
              HttpRequest request, ILogger logger, string type)
        {
            List<Picklist> PickLists = new List<Picklist>();
           
            try
            {
                var req = new GetPickListCommand()
                {
                   Type = type
                };
                var result = await Mediator.Send(req);
                return SendSuccessfulResult(Type, result);

            }
            catch (Exception ex)
            {
                return SendFailedResult(ex, Type, logger);
            }
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [FunctionName("DeletePickList")]
        public async Task<IActionResult> DeletePickList(
          [HttpTrigger(AuthorizationLevel.Anonymous, "Delete", Route = "pickLists/{type}")]
          HttpRequest request,
          ILogger logger,
          string type)
        {
            try
            {
                logger.LogInformation("GetPickList called");

                string id = request.Query["Id"];
                string isActive = request.Query["IsActive"];
                string appId = request.Query["AppId"];
                

                var query = new GetPickListCommand()
                {
                                  
                };

                var result = await Mediator.Send(query);
                return result != null ? SendSuccessfulGetResult(type, result) : SendNotFoundResult($"Table '{type}' not found", type, logger);
            }
            catch (Exception ex)
            {
                return SendFailedResult(ex, type, logger);
            }

        }

        [OpenApiOperation("PickList", "PickList")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Picklist))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [FunctionName("AddPickLists")]
        public async Task<IActionResult> AddPickList(
        [HttpTrigger(AuthorizationLevel.Anonymous, "Post", Route = "PickList")]HttpRequest request, ILogger logger)
        {
            List<Picklist> PickLists = new List<Picklist>();
            ;
            try
            {
                var validateRequest = await request.GetJsonBody<AddPickListCommand, AddPickListCommandValidator>();

                if (!validateRequest.IsValid)
                {
                    return SendFailedValidationResult(validateRequest, Type);
                }
                var result = await Mediator.Send(validateRequest.Value);
                return SendSuccessfulResult(Type, result, validateRequest);

            }
            catch (Exception ex)
            {
                return SendFailedResult(ex, Type, logger);
            }
        }

        //[OpenApiOperation("PickList", "PickList")]
        //[OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Picklist))]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //[FunctionName("UpdatePickLists")]
        //public async Task<IActionResult> UpdatePickList(

        //  [HttpTrigger(AuthorizationLevel.Anonymous, "Put", Route = "PickList")]
        //      HttpRequest request, ILogger logger)
        //{
        //    List<PickList> PickLists = new List<PickList>();
        //    ;
        //    try
        //    {
        //        //var result = await Mediator.Send(new GetPickListsCommand());
        //        var validateRequest = await request.GetJsonBody<UpdatePickListsCommand, UpdatePickListCommandValidator>();

        //        if (!validateRequest.IsValid)
        //        {
        //            return SendFailedValidationResult(validateRequest, Type);
        //        }

        //        var result = await Mediator.Send(validateRequest.Value);
        //        return SendSuccessfulResult(Type, result, validateRequest);

        //    }
        //    catch (Exception ex)
        //    {
        //        return SendFailedResult(ex, Type, logger);
        //    }
        //}
    }
}
