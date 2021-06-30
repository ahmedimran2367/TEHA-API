// <copyright file="ApiResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using TEHA.Portal.Data;
    using TEHA.Portal.Data.Models.Validation;

    /// <summary>
    /// Response Status
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        OK = 0,

        /// <summary>
        /// Error
        /// </summary>
        Error = 2,

        /// <summary>
        /// Info
        /// </summary>
        Info = 1,

        /// <summary>
        /// Warning
        /// </summary>
        Warning = 3,

        /// <summary>
        /// LimitExceeded
        /// </summary>
        LimitExceeded = 4,

        /// <summary>
        /// Forbidden
        /// </summary>
        Forbidden = 5,

        /// <summary>
        /// Unauthorized
        /// </summary>
        Unauthorized = 6,

        /// <summary>
        /// NoContent
        /// </summary>
        NoContent = 204,

        /// <summary>
        /// NoContent
        /// </summary>
        ValidationError = 409,

        /// <summary>
        /// Bad Request
        /// </summary>
        BadRequest = 400,
    }

    /// <summary>
    /// Implements Controller Extensions.
    /// </summary>
    public static class ApiResponse
    {
        /// <summary>
        /// Result for object.
        /// </summary>
        /// <typeparam name="T">Model which belongs to object</typeparam>
        /// <param name="controller">Controller to attach extension method</param>
        /// <param name="status">Response Status</param>
        /// <param name="data">object</param>
        /// <param name="message">Message</param>
        /// <returns>Action response</returns>
        public static ActionResult Result<T>(this ControllerBase controller, ResponseStatus status, T data = default(T), string message = null)
        {
            return new Response<T>()
            {
                Status = status,
                Data = data,
                Message = message,
            };
        }

        /// <summary>
        /// Result for type object
        /// </summary>
        /// <param name="controller">Controller to attach extension method</param>
        /// <param name="status">Response Status</param>
        /// <param name="data">type object</param>
        /// <param name="message">Message</param>
        /// <returns>Action response</returns>
        public static IActionResult Result(this ControllerBase controller, ResponseStatus status, object data = null, string message = null)
        {
            return new Response<object>()
            {
                Status = status,
                Data = data,
                Message = message,
            };
        }

        /// <summary>
        /// Returns reponse of http request
        /// </summary>
        /// <typeparam name="T">Generic</typeparam>
        /// <param name="controller">controller</param>
        /// <param name="response">response</param>
        /// <returns>ActionResult</returns>
        public static async Task<IActionResult> Result<T>(this ControllerBase controller, HttpResponseMessage response)
        {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return new OkObjectResult(Result(controller, ResponseStatus.OK, true, null));
                    }

                    var obj = JsonConvert.DeserializeObject<ProxyResponse<T>>(content);
                    return new OkObjectResult(Result(controller, ResponseStatus.OK, obj.Data, null));
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    var obj = JsonConvert.DeserializeObject<ProxyResponse<List<Error>>>(await response.Content.ReadAsStringAsync());
                    return new ConflictObjectResult(Result(controller, ResponseStatus.ValidationError, obj.Errors, null));
                }
                else
                {
                    return await ErrorResult(controller, response);
                }
        }

        /// <summary>
        /// Error Result
        /// Make Error response
        /// </summary>
        /// <param name="controller">Controller</param>
        /// <param name="response">HttpResponseMessage </param>
        /// <param name="errorException">Error Exception </param>
        /// <returns>Result</returns>
        public static async Task<IActionResult> ErrorResult(this ControllerBase controller, HttpResponseMessage response, string errorException = null)
        {
            IActionResult responseObject = null;

            var content = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(content))
            {
                responseObject = Result(controller, ResponseStatus.Error, null, $"{response.ReasonPhrase}");
            }

            if (!string.IsNullOrEmpty(errorException))
            {
                responseObject = Result(controller, ResponseStatus.Error, null, $"500-{errorException}");
                return new ObjectResult(responseObject)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }

            if (responseObject == null)
            {
                var obj = JsonConvert.DeserializeObject<ProxyResponse<string>>(await response.Content.ReadAsStringAsync());

                string error = obj.Error;
                if (string.IsNullOrEmpty(error))
                {
                    obj.Errors.ForEach(e => error += " " + e.Description);
                }

                if (string.IsNullOrEmpty(error))
                {
                    responseObject = Result(controller, ResponseStatus.Error, null, $"{obj.Status}");
                }
                else
                {
                    responseObject = Result(controller, ResponseStatus.Error, null, $"{obj.Status}-{error}");
                }
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return new ObjectResult(responseObject)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return new BadRequestObjectResult(responseObject);
            }
            else
            {
                return new NotFoundObjectResult(responseObject);
            }
        }
    }
}
