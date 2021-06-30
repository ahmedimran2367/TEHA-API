// <copyright file="UserSettingService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Services.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using BITLogix.Core.Couchbase;
    using TEHA.Portal.Data.Models.Administration;

    /// <summary>
    /// contains user specific settings
    /// </summary>
    public class UserSettingService
    {
        private readonly IDbClient<UserSetting> dbClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSettingService"/> class.
        /// </summary>
        /// <param name="configuration">configruation</param>
        public UserSettingService(IConfiguration configuration)
        {
            this.dbClient = DbClientFactory.Default.Create<UserSetting>(configuration);
        }

        /// <summary>
        /// Gets list of all system settings
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>UserSetting</returns>
        public UserSetting Get(int id)
        {
            return this.dbClient.FirstOrDefault(x => x.UserId == id);
        }

        /// <summary>
        /// implements update
        /// </summary>
        /// <param name="userSetting">userSetting</param>
        public void CreateOrUpdate(UserSetting userSetting)
        {
            userSetting.Type = "UserSetting";
            var id = this.dbClient.FirstOrDefault(x => x.UserId == userSetting.UserId)?.Id;
            if (id != null)
            {
                userSetting.Id = (int)id;
                this.dbClient.Update(userSetting);
            }
            else
            {
                this.dbClient.Insert(userSetting);
            }
        }
    }
}
