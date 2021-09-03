using Application.Products.Commands.GetProducts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Extension;
using WebApi.Validators.Models;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private const string Type = "Product";
        public ProductController(ILogger<ApiController> logger, IHttpContextAccessor httpContextAccessor) : base(logger, httpContextAccessor)
        {
        }

        public async Task<IActionResult> GetProducts(
            HttpRequest request,ILogger logger)
        {
            List<Product> products = new List<Product>();
                ;
            try
            {
                var validateRequest = await request.GetJsonBody<GetProductsCommand, GetProductCommandValidator>();

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
