// <copyright file="TestBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Test.Helper
{
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data.Models.Account;
    using TEHA.Portal.ProxyAPI.Clients.Account;

    /// <summary>
    /// Base Class for testing
    /// </summary>
    public class TestBase
    {
        private readonly AccountClient accountClient = new AccountClient();

        /// <summary>
        /// Gets User with username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Data.Models.Account.User</returns>
        public async Task<Data.Models.Account.User> GetUser(string username)
        {
            var response = await this.accountClient.Login(new UserCredential()
            {
                Username = username,
                Password = "33DCMnPg7XHGcCrD",
            });

            Response<Data.Models.Account.User> userResponse = JsonConvert.DeserializeObject<Response<Data.Models.Account.User>>(await response.Content.ReadAsStringAsync());

            if (userResponse.Data != null)
            {
                userResponse.Data.ExternalToken = userResponse.Data.Token;
            }

            return userResponse.Data;
        }
    }
}
