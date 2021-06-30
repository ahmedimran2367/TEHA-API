// <copyright file="IAccountClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.ProxyAPI.Clients.Account
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using TEHA.Portal.Data.Models.Account;

    /// <summary>
    /// Account endpoints methods
    /// </summary>
    public interface IAccountClient
    {
        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="userCredential">User Credebtials</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> Login(UserCredential userCredential);

        /// <summary>
        /// Gets User Contact Information
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="userId">User ID</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> GetUserContactInformation(string token, int userId);

        /// <summary>
        /// Get General settings for a user or for a specific property
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="id">User ID</param>
        /// <param name="propertyId">Property ID</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> GetGeneralSetting(string token, int id, int? propertyId);

        /// <summary>
        /// Get Detail
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="id">User ID</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> Detail(string token, int id);

        /// <summary>
        /// Update General Settings
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="updateGeneralSettingRequest">UpdateGeneralSettingRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> UpdateGeneralSetting(string token, UpdateGeneralSettingRequest updateGeneralSettingRequest);

        /// <summary>
        /// Edits or update Team Member details
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="updateMemberDetailsRequest">UpdateMemberDetailsRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> EditTeamMember(string token, UpdateMemberDetailsRequest updateMemberDetailsRequest);

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="changePasswordRequest">ChangePasswordRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> ChangePassword(string token, ChangePasswordRequest changePasswordRequest);

        /// <summary>
        /// Add team member
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="teamMemberDetail">teamMemberDetail</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> AddTeamMember(string token, TeamMemberDetail teamMemberDetail);

        /// <summary>
        /// Update Member Properties
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="updateMemberPropertyRequest">UpdateMemberPropertyRequest</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> UpdateMemberProperties(string token, UpdateMemberPropertyRequest updateMemberPropertyRequest);

        /// <summary>
        /// Forgot Password
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> ForgotPassword(string username);

        /// <summary>
        /// Update Contact Infomation
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="updateContactInfoRequest">UpdateContactInformation</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> UpdateContactInformation(string token, UpdateContactInfoRequest updateContactInfoRequest);
    }
}