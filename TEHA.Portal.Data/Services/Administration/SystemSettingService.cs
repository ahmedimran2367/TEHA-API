// <copyright file="SystemSettingService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Services.Administration
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using BITLogix.Core.Couchbase;
    using TEHA.Portal.Data.Models.Administration;
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// System Settings Data store
    /// </summary>
    public class SystemSettingService
    {
        private readonly IDbClient<SystemSetting> dbClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemSettingService"/> class.
        /// </summary>
        /// <param name="configuration">configruation</param>
        public SystemSettingService(IConfiguration configuration)
        {
            this.dbClient = DbClientFactory.Default.Create<SystemSetting>(configuration);
        }

        /// <summary>
        /// Gets list of all system settings
        /// </summary>
        /// <returns>List<TEHA.Portal.Data.Models.Admin.EmailTemplate></returns>
        public List<SystemSetting> GetAll()
        {
            return this.dbClient.GetAll().ToList();
        }

        /// <summary>
        /// GetDocumentJsonContent
        /// </summary>
        /// <returns>DocumentJsonContent</returns>
        public async Task<FileContentResponse> GetDocumentJsonContent()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents.json");
            if (!System.IO.File.Exists(filePath))
            {
                return new FileContentResponse
                {
                    Content = null,
                    Filename = null,
                };
            }

            byte[] bytes;
            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
                bytes = memory.ToArray();
            }

            memory.Position = 0;
            return new FileContentResponse
            {
                Content = Convert.ToBase64String(bytes),
                Filename = "documents.json",
            };
        }

        /// <summary>
        /// Gets list of all system settings
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>List<TEHA.Portal.Data.Models.Admin.EmailTemplate></returns>
        public SettingsResult GetAllSettings(SettingsRequest request)
        {
            List<SystemSetting> list = this.dbClient.GetAll().ToList();

            int totalCount = list.Count;
            ////list = list
            ////.Skip((request.PageNo - 1) * request.PageSize)
            ////.Take(request.PageSize).OrderBy(x => x.Id).ToList();
            list = list.Skip(request.PageNo * request.PageSize).Take(request.PageSize).OrderBy(x => x.Id).ToList();
            return new SettingsResult()
            {
                Items = list,
                TotalRecords = totalCount,
            };
        }

        /// <summary>
        /// implements update
        /// </summary>
        /// <param name="systemSettings">systemSettings</param>
        public void Update(SystemSetting systemSettings)
        {
            this.dbClient.Update(systemSettings);
        }
    }
}
