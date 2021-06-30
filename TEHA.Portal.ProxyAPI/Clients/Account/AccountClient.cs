// <copyright file="AccountClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Account
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.Data.Models.Account;
    using TEHA.Portal.ProxyAPI.Constant;

    /// <summary>
    /// Account Client
    /// </summary>
    public class AccountClient : IAccountClient
    {
        private readonly RestClient restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountClient"/> class.
        /// </summary>
        public AccountClient()
        {
            this.restClient = new RestClient();
        }

        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="userCredential">User Credebtials</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Login(UserCredential userCredential)
        {
            return await this.restClient.Post(Url.AccountLogin, userCredential);
        }

        /// <summary>
        /// Gets User Contact Information
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="userId">User ID</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetUserContactInformation(string token, int userId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            return await this.restClient.Get(Url.UserContactInformation, parameters, token);
        }

        /// <summary>
        /// Get General settings for a user or for a specific property
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="id">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetGeneralSetting(string token, int id, int? propertyId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());
            parameters.Add("propertyId", propertyId.ToString());
            return await this.restClient.Get(Url.GetGeneralSetting, parameters, token);
        }

        /// <summary>
        /// Get Detail
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="id">User ID</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> Detail(string token, int id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());
            return await this.restClient.Get(Url.Detail, parameters, token);
        }

        /// <summary>
        /// Update General Settings
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="updateGeneralSettingRequest">UpdateGeneralSettingRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> UpdateGeneralSetting(string token, UpdateGeneralSettingRequest updateGeneralSettingRequest)
        {
            return await this.restClient.Put(Url.UpdateGeneralSetting, updateGeneralSettingRequest, token);
        }

        /// <summary>
        /// Edits or update Team Member details
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="updateMemberDetailsRequest">UpdateMemberDetailsRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> EditTeamMember(string token, UpdateMemberDetailsRequest updateMemberDetailsRequest)
        {
            return await this.restClient.Put(Url.EditTeamMember, updateMemberDetailsRequest, token);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="changePasswordRequest">ChangePasswordRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> ChangePassword(string token, ChangePasswordRequest changePasswordRequest)
        {
            return await this.restClient.Put(Url.ChangePassword, changePasswordRequest, token);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="teamMemberDetail">TeamMemberDetail</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> AddTeamMember(string token, TeamMemberDetail teamMemberDetail)
        {
            return await this.restClient.Post(Url.AddTeamMember, teamMemberDetail, token);
        }

        /// <summary>
        /// Update Member Properties
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="updateMemberPropertyRequest">UpdateMemberPropertyRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> UpdateMemberProperties(string token, UpdateMemberPropertyRequest updateMemberPropertyRequest)
        {
            return await this.restClient.Put(Url.UpdateMemberProperties, updateMemberPropertyRequest, token);
        }

        /// <summary>
        /// Forgot Password
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> ForgotPassword(string username)
        {
            return await this.restClient.Post(Url.ForgotPassword, username);
        }

        /// <summary>
        /// Update Contact Infomation
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="updateContactInfoRequest">UpdateContactInformation</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> UpdateContactInformation(string token, UpdateContactInfoRequest updateContactInfoRequest)
        {
            return await this.restClient.Put(Url.UpdateContactInfomation, updateContactInfoRequest, token);
        }
    }
}
