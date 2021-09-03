using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FunctionApi.Models;

namespace FunctionApi.Extension
{  
        public static class HttpRequestExtensions
        {
            /// <summary>
            ///     Returns the deserialized request body with validation information.
            /// </summary>
            /// <typeparam name="T">Type used for deserialization of the request body.</typeparam>
            /// <typeparam name="V">
            ///     Validator used to validate the deserialized request body.
            /// </typeparam>
            /// <param name="request"></param>
            /// <returns></returns>
            public static async Task<ValidateRequest<T>> GetJsonBody<T, V>(this HttpRequest request)
                where V : AbstractValidator<T>, new()
            {
                var requestObject = await request.GetJsonBody<T>();
                var validator = new V();
                var validationResult = await validator.ValidateAsync(requestObject);

                if (!validationResult.IsValid)
                {
                    return new ValidateRequest<T>
                    {
                        Value = requestObject,
                        IsValid = false,
                        Errors = validationResult.Errors
                    };
                }

                return new ValidateRequest<T>
                {
                    Value = requestObject,
                    IsValid = true
                };
            }

            /// <summary>
            ///     Returns the deserialized request body.
            /// </summary>
            /// <typeparam name="T">Type used for deserialization of the request body.</typeparam>
            /// <param name="request"></param>
            /// <returns></returns>
            private static async Task<T> GetJsonBody<T>(this HttpRequest request)
            {
                //var test = await request.ReadAsStringAsync();

                var requestBody = await new StreamReader(request.Body).ReadToEndAsync();

                return JsonConvert.DeserializeObject<T>(requestBody);
            }
        }
    }

