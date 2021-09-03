using Aliencube.AzureFunctions.Extensions.OpenApi.Core.Attributes;
using Application.PickListHelper.Commands.AddPickListHelper;
using Application.PickListHelper.Commands.GetPickListHelper;
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
    [ApiExplorerSettings(GroupName = "PickListHelper")]

    public class PickListHelperController : ApiController
    {
        private const string Type = "PickListHelper";
        public PickListHelperController(ILogger<ApiController> logger, IHttpContextAccessor httpContextAccessor) : base(logger, httpContextAccessor)
        {
        }
        [OpenApiOperation("PickListHelper", "PickListHelper")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(PicklistHelper))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [FunctionName("GetPickListHelper")]
        public async Task<IActionResult> PickListHelpers(

            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "PickListHelper/{type}")]
              HttpRequest request, ILogger logger, string type)
        {
            List<PicklistHelper> PickListHelpers = new List<PicklistHelper>();
            
            try
            {
                var req = new GetPickListHelperCommand()
                {
                   TableName = type
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
        [FunctionName("DeletePickListHelper")]
        //[QueryStringParameter("Id", "", DataType = typeof(string), RequiredAttribute = false)]
        //[QueryStringParameter("IsActive", "", DataType = typeof(string), Required = false)]
        //[QueryStringParameter("AppId", "", DataType = typeof(string), Required = false)]
        //[QueryStringParameter("PageNumber", "", DataType = typeof(string), Required = false)]
        //[QueryStringParameter("PageSize", "", DataType = typeof(string), Required = false)]
        public async Task<IActionResult> DeletePickListHelper(
          [HttpTrigger(AuthorizationLevel.Anonymous, "Delete", Route = "PickListHelpers/{type}")]
          HttpRequest request,
          ILogger logger,
          string type)
        {
            try
            {
                logger.LogInformation("GetPickListHelper called");

                string id = request.Query["Id"];
                string isActive = request.Query["IsActive"];
                string appId = request.Query["AppId"];
                

                var query = new GetPickListHelperCommand()
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

        [OpenApiOperation("PickListHelper", "PickListHelper")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(PicklistHelper))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [FunctionName("AddPickListHelpers")]
        public async Task<IActionResult> AddPickListHelper(
        [HttpTrigger(AuthorizationLevel.Anonymous, "Post", Route = "PickListHelper")]HttpRequest request, ILogger logger)
        {
            List<PicklistHelper> PickListHelpers = new List<PicklistHelper>();
            ;
            try
            {
                var validateRequest = await request.GetJsonBody<AddPickListHelperCommand, AddPickListHelperCommandValidator>();

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

        //[OpenApiOperation("PickListHelper", "PickListHelper")]
        //[OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(PickListHelper))]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //[FunctionName("UpdatePickListHelpers")]
        //public async Task<IActionResult> UpdatePickListHelper(

        //  [HttpTrigger(AuthorizationLevel.Anonymous, "Put", Route = "PickListHelper")]
        //      HttpRequest request, ILogger logger)
        //{
        //    List<PickListHelper> PickListHelpers = new List<PickListHelper>();
        //    ;
        //    try
        //    {
        //        //var result = await Mediator.Send(new GetPickListHelpersCommand());
        //        var validateRequest = await request.GetJsonBody<UpdatePickListHelpersCommand, UpdatePickListHelperCommandValidator>();

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
