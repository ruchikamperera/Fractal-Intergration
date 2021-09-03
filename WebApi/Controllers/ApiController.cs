using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public abstract class ApiController : ControllerBase
    {

        private readonly ILogger<ApiController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IMediator _mediator;

        protected ApiController(ILogger<ApiController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        protected IMediator Mediator
        {
            get
            {
                return _mediator ??= (IMediator)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IMediator));
            }
        }

        [NonAction]
        protected virtual IActionResult SendSuccessfulResult(string type, dynamic result, dynamic validateRequest = null)
        {
            var method = _httpContextAccessor.HttpContext.Request.Method;
            var actionName = $"{method}_{type}";

            _logger.LogInformation($"Successful request for {actionName} : {JsonConvert.SerializeObject(validateRequest?.Value)}");

            var name = type.First().ToString().ToUpper() + type[1..];

            var actionType = method switch
            {
                "POST" => "created",
                "PUT" => "updated",
                "DELETE" => "deleted",
                _ => string.Empty
            };

            dynamic response;

            if (actionName == "POST_TimeLog" || actionName == "PUT_TimeLog")
            {
                response = new
                {
                    Success = true,
                    Message = $"{name} with id: {JsonConvert.SerializeObject(result)} successfully {actionType}",
                    Ids = result
                };
            }
            else
            {
                response = new
                {
                    Success = true,
                    Message = $"{name} with id: {result} successfully {actionType}",
                    Ids = result
                };
            }


            _logger.LogInformation($"Successful response for {actionName} : {response}");

            return new OkObjectResult(response);


        }

        [NonAction]
        protected virtual IActionResult SendFailedResult(Exception ex, string type, ILogger logger)
        {
            var actionName = $"{_httpContextAccessor.HttpContext.Request.Method}_{type}";

            var response = new
            {
                Success = false,
                Message = ex.InnerException == null ? ex.Message : $"{ex.Message} --> {ex.InnerException.Message}"
            };

            logger.LogError($"Failed response for {actionName} : {response}");

            return new BadRequestObjectResult(response);
        }

        [NonAction]
        protected virtual IActionResult SendFailedValidationResult(dynamic validateRequest, string type)
        {
            var actionName = $"{_httpContextAccessor.HttpContext.Request.Method}_{type}";

            _logger.LogError($"Failed request for {actionName} : {JsonConvert.SerializeObject(validateRequest.Value)}");

            var errors = (IList<ValidationFailure>)validateRequest.Errors;

            var errorList = errors.Select(e => new
            {
                Field = e.PropertyName,
                Error = e.ErrorMessage
            });

            var errResponse = new BadRequestObjectResult(new
            {
                Success = false,
                Message = errorList
            });

            _logger.LogError($"Failed response for {actionName} : {JsonConvert.SerializeObject(errResponse)}");

            return errResponse;
        }

        [NonAction]
        protected virtual IActionResult SendNotFoundResult(string message, string type, ILogger logger)
        {
            var actionName = $"{_httpContextAccessor.HttpContext.Request.Method}_{type}";

            var response = new
            {
                Success = false,
                Message = message
            };

            logger.LogError($"Failed response for {actionName} : {response}");

            return new NotFoundObjectResult(response);
        }

        [NonAction]
        protected virtual IActionResult SendBadRequestObjectResult(string message, string type, ILogger logger)
        {
            var actionName = $"{_httpContextAccessor.HttpContext.Request.Method}_{type}";

            var response = new
            {
                Success = false,
                Message = message
            };

            logger.LogError($"Failed response for {actionName} : {response}");

            return new BadRequestObjectResult(response);
        }

        [NonAction]
        protected virtual IActionResult SendSuccessfulGetResult(string type, object result)
        {
            var method = _httpContextAccessor.HttpContext.Request.Method;

            var actionName = $"{method}_{type}";

            _logger.LogInformation($"Successful response for {actionName} : {JsonConvert.SerializeObject(result)}");

            return new OkObjectResult(result);
        }

    }
}
