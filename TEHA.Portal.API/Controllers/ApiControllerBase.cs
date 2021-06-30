// <copyright file="ApiControllerBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TEHA.Portal.API.Helpers;
    using TEHA.Portal.Data.Models.Account;

    /// <summary>
    /// Implements Base DataStore Unit of Work
    /// </summary>
    [AuthorizeCustomAttribute]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private User currentUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerBase"/> class.
        /// </summary>
        public ApiControllerBase()
        {
        }

        /// <summary>
        /// Gets or sets intialization of Current User
        /// </summary>
        public User CurrentUser
        {
            get
            {
                if (this.currentUser == null)
                {
                    // For Production
                    dynamic user = this.HttpContext.Items["User"];
                    if (user != null)
                    {
                        this.currentUser = user;
                    }

                    return this.currentUser;
                }
                else
                {
                    return this.currentUser;
                }
            }

            set
            {
                this.currentUser = value;
            }
        }
    }
}