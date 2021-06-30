// <copyright file="LanguageController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers.Administration
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.API.Helpers.Language;
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.Data.Models.Language;
    using TEHA.Portal.Data.Services.Administration;

    /// <summary>
    /// Implements language translations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ApiControllerBase
    {
        private readonly LanguageService languageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageController"/> class.
        /// </summary>
        /// <param name="languageService">initialze</param>
        public LanguageController(LanguageService languageService)
        {
            this.languageService = languageService;
        }

        /// <summary>
        /// language
        /// </summary>
        /// <remarks>Returns list Language . Admin Module</remarks>
        /// <param name="languageRequest">freeSearch</param>
        /// <response code="200">OK</response>
        /// <returns>translations</returns>
       // [AllowAnonymous]
        [HttpPost]
        [Route("Get")]
        [AllowAnonymous]
        public virtual IActionResult Get([FromBody] LanguageRequest languageRequest)
        {
            LanguageResult list = this.languageService.GetAllLanguages(languageRequest);
            return new OkObjectResult(this.Result(ResponseStatus.OK, list, null));
        }

        /// <summary>
        /// Language
        /// </summary>
        /// <remarks>Updates Language. Admin Module</remarks>
        /// <param name="language">language</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        /// <returns>ok</returns>
        [AllowAnonymous]
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] Language language)
        {
            this.languageService.Update(language);
            LanguageManager.Refresh();
            return this.Result(ResponseStatus.OK, null, null);
        }
    }
}
