// <copyright file="LanguageService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Services.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using BITLogix.Core.Couchbase;
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.Data.Models.Language;

    /// <summary>
    /// System Translation Data store
    /// </summary>
    public class LanguageService
    {
        private readonly IDbClient<Language> dbClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageService"/> class.
        /// </summary>
        /// <param name="configuration">configruation</param>
        public LanguageService(IConfiguration configuration)
        {
            this.dbClient = DbClientFactory.Default.Create<Language>(configuration);
        }

        /// <summary>
        /// Gets list of all languages
        /// </summary>
        /// <param name="category">freeSearch</param>
        /// <returns>List<languages></returns>
        public List<Language> GetAll(string category = "")
        {
            List<Language> list;
            if (category == "all")
            {
                list = this.dbClient.GetAll().ToList();
            }
            else
            {
                list = this.dbClient.GetAll().Where(x => x.Category.ToLower() == category.ToLower()).ToList();
            }

            return list;
        }

        /// <summary>
        /// Gets list of all languages
        /// </summary>
        /// <param name="languageRequest">languageRequest</param>
        /// <returns>List<languages></returns>
        public LanguageResult GetAllLanguages(LanguageRequest languageRequest)
        {
            List<Language> list;
            if (languageRequest.Category == "all" || languageRequest.Category == null)
            {
                list = this.dbClient.GetAll().ToList();
            }
            else
            {
                list = this.dbClient.GetAll().Where(x => x.Category.ToLower() == languageRequest.Category.ToLower()).ToList();
            }

            if (!string.IsNullOrEmpty(languageRequest.FreeSearch))
            {
                list = list.Where(
             x =>
             (!string.IsNullOrEmpty(x.Code) && x.Code.ToLower().Contains(languageRequest.FreeSearch.ToLower())) ||
             (!string.IsNullOrEmpty(x.English) && x.English.ToLower().Contains(languageRequest.FreeSearch.ToLower())) ||
             (!string.IsNullOrEmpty(x.German) && x.German.ToLower().Contains(languageRequest.FreeSearch.ToLower())) ||
             (!string.IsNullOrEmpty(x.Category) && x.Category.ToLower().Contains(languageRequest.FreeSearch.ToLower())))
             .ToList();
            }

            list = languageRequest.Sort.Direction == "asc" ? list.OrderBy(x => x.English).ToList() : list.OrderByDescending(x => x.English).ToList();
            int totalCount = list.Count;
            list = list.Skip(languageRequest.PageNo * languageRequest.PageSize).Take(languageRequest.PageSize).ToList();
            return new LanguageResult()
            {
                Items = list,
                TotalRecords = totalCount,
            };
        }

        /// <summary>
        /// implements update
        /// </summary>
        /// <param name="language">languages</param>
        public void Update(Language language)
        {
            this.dbClient.Update(language);
        }
    }
}
