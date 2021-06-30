// <copyright file="Response.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Helpers
{
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Response
    /// </summary>
    /// <typeparam name="T">Generic</typeparam>
    public class Response<T> : ActionResult
    {
        private readonly ContentResult contentResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class.
        /// </summary>
        public Response()
        {
            this.contentResult = new ContentResult();
        }

        /// <summary>
        /// Gets or sets status
        /// <list type="ResponseStatus">
        /// <item>OK</item>
        /// <item>Info</item>
        /// <item>Error</item>
        /// <item>Warning</item>
        /// <item>LimitExceeded</item>
        /// <item>Forbidden</item>
        /// <item>Unauthorized</item>
        /// </list>
        /// </summary>
        public ResponseStatus Status { get; set; }

        /// <summary>
        /// Gets or sets message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Result Executor
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>Status</returns>
        public async override Task ExecuteResultAsync(ActionContext context)
        {
            if (this.contentResult.StatusCode.HasValue)
            {
                this.contentResult.StatusCode = this.Status == ResponseStatus.Error ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK;
            }

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ContractResolver = new DefaultContractResolver(),
            };

            StringBuilder sb = new StringBuilder(JsonConvert.SerializeObject(this));
            this.contentResult.Content = sb.ToString();
            this.contentResult.ContentType = "application/json";
            await this.contentResult.ExecuteResultAsync(context);
        }
    }
}
