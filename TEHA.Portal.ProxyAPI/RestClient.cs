// <copyright file="RestClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Contains Rest Methods
    /// </summary>
    public class RestClient
    {
        /// <summary>
        /// http Client
        /// </summary>
        private readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient"/> class.
        /// </summary>
        public RestClient()
        {
            ConfigurationBuilder builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            IConfigurationRoot config = builder.AddJsonFile("appsettings.json").Build();
            this.httpClient.BaseAddress = new Uri(config.GetSection("AppSettings").GetValue<string>("tehaInternalAPIBaseUrl"));
            this.httpClient.Timeout = TimeSpan.FromMinutes(3);
        }

        /// <summary>
        /// Get Http Request
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="parameters">parameters</param>
        /// <param name="token">token</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Get(string url, Dictionary<string, string> parameters, string token = null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            HttpResponseMessage response = await this.httpClient.GetAsync(parameters == null ? url : $"{url}?{string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"))}").ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Delete Http Request
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="parameters">parameters</param>
        /// <param name="token">token</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Delete(string url, Dictionary<string, string> parameters, string token = null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            HttpResponseMessage response = await this.httpClient.DeleteAsync(parameters == null ? url : $"{url}?{string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"))}").ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Post http Request
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="body">body</param>
        /// <param name="token">token</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Post(string url, object body, string token = null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            HttpResponseMessage response = await this.httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(body, options), UnicodeEncoding.UTF8, "application/json")).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Put http Request
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="body">body</param>
        /// <param name="token">token</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Put(string url, object body, string token = null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            HttpResponseMessage response = await this.httpClient.PutAsync(url, new StringContent(JsonSerializer.Serialize(body, options), UnicodeEncoding.UTF8, "application/json")).ConfigureAwait(false);
            return response;
        }
    }
}
