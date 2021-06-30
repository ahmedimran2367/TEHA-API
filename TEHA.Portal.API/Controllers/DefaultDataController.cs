// <copyright file="DefaultDataController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.API.Helpers.Language;
    using TEHA.Portal.API.Helpers.Lookups;
    using TEHA.Portal.API.Helpers.Settings;
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.ProxyAPI.Clients.Lookup;

    /// <summary>
    /// Implements app default data
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultDataController : ApiControllerBase
    {
        private readonly ILookupClient lookupClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDataController"/> class.
        /// </summary>
        /// <param name="lookupClient">ILookupClient</param>
        public DefaultDataController(ILookupClient lookupClient)
        {
            this.lookupClient = lookupClient;
        }

        /// <summary>
        /// DefaultData
        /// </summary>
        /// <remarks>Returns Default(system settigs,multilingual and lookups) data </remarks>
        /// <response code="200">OK</response>
        /// <returns>ok</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("Get")]
        public IActionResult Get()
        {
            DefaultData defaultData = new DefaultData()
            {
                LookUps = LookupsManager.GetLookups(),
                SystemSettings = SystemSettingsManager.GetSystemSettingMessages(),
            };
            return new OkObjectResult(this.Result(ResponseStatus.OK, defaultData, null));
        }

        /// <summary>
        /// DefaultData
        /// </summary>
        /// <param name="lang">lang</param>
        /// <remarks>Returns Default(system settigs,multilingual and lookups) data </remarks>
        /// <response code="200">OK</response>
        /// <returns>ok</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetLanguage")]
        public IActionResult GetLanguage(string lang)
        {
            if (lang == "en")
            {
                var result = LanguageManager.GetEnglishMessages();
                return new OkObjectResult(this.Result(ResponseStatus.OK, result, null));
            }
            else
            {
                var result = LanguageManager.GetGermanMessages();
                return new OkObjectResult(this.Result(ResponseStatus.OK, result, null));
            }
        }
    }
}
