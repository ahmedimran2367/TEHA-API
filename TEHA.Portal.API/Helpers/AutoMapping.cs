// <copyright file="AutoMapping.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Helpers
{
    using AutoMapper;
    using TEHA.Portal.Data.Models.Account;

    /// <summary>
    /// Auto Mapping
    /// </summary>
    public class AutoMapping : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapping"/> class.
        /// </summary>
        public AutoMapping()
        {
            this.CreateMap<UserLoginResponse, User>();
        }
    }
}
