using Aliencube.AzureFunctions.Extensions.OpenApi;
using Aliencube.AzureFunctions.Extensions.OpenApi.Core.Attributes;
using Application.Products.Commands.AddProducts;
using Application.Products.Commands.GetProducts;
using Domain.Entities;
using FunctionApi.Extension;
using FunctionApi.Validators.Models;
using FunctionApi.Validators.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApi.Controllers
{
    [ApiExplorerSettings(GroupName = "ProductList")]

    public class ProductController : ApiController
    {
        private const string Type = "Product";
        public ProductController(ILogger<ApiController> logger, IHttpContextAccessor httpContextAccessor) : base(logger, httpContextAccessor)
        {
        }
        [OpenApiOperation("Product", "Product")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Product))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [FunctionName("GetProducts")]
        public async Task<IActionResult> Products(

            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "Product")]
              HttpRequest request, ILogger logger)
        {
            List<Product> products = new List<Product>();
            ;
            try
            {
                var req = new GetProductsCommand()
                {
                    Id = 1

                };
                //var result = await Mediator.Send(new GetProductsCommand());
                // var validateRequest = await request.GetJsonBody<GetProductsCommand, GetProductCommandValidator>();

                //if (!validateRequest.IsValid)
                //{
                //    return SendFailedValidationResult(validateRequest, Type);
                //}

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
        [FunctionName("GetPickList")]
        //[QueryStringParameter("Id", "", DataType = typeof(string), RequiredAttribute = false)]
        //[QueryStringParameter("IsActive", "", DataType = typeof(string), Required = false)]
        //[QueryStringParameter("AppId", "", DataType = typeof(string), Required = false)]
        //[QueryStringParameter("PageNumber", "", DataType = typeof(string), Required = false)]
        //[QueryStringParameter("PageSize", "", DataType = typeof(string), Required = false)]
        public async Task<IActionResult> GetPickList(
          [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "pickLists/{type}")]
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
                string pageNumber = request.Query["PageNumber"];
                string pageSize = request.Query["PageSize"];

                var query = new GetProductsCommand()
                {
                    Id = 1,
                   

                };

                var result = await Mediator.Send(query);

                return result != null ? SendSuccessfulGetResult(type, result) : SendNotFoundResult($"Table '{type}' not found", type, logger);
            }
            catch (Exception ex)
            {
                return SendFailedResult(ex, type, logger);
            }

        }

        [OpenApiOperation("Product", "Product")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Product))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [FunctionName("AddProducts")]
        public async Task<IActionResult> AddProduct(

           [HttpTrigger(AuthorizationLevel.Anonymous, "Post", Route = "Product")]
              HttpRequest request, ILogger logger)
        {
            List<Product> products = new List<Product>();
            ;
            try
            {
                //var result = await Mediator.Send(new GetProductsCommand());
                var validateRequest = await request.GetJsonBody<AddProductsCommand, AddProductCommandValidator>();

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

        [OpenApiOperation("Product", "Product")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Product))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [FunctionName("UpdateProducts")]
        public async Task<IActionResult> UpdateProduct(

          [HttpTrigger(AuthorizationLevel.Anonymous, "Put", Route = "Product")]
              HttpRequest request, ILogger logger)
        {
            List<Product> products = new List<Product>();
            ;
            try
            {
                //var result = await Mediator.Send(new GetProductsCommand());
                var validateRequest = await request.GetJsonBody<UpdateProductsCommand, UpdateProductCommandValidator>();

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
    }
}
