// <copyright file="AuthorizeCustomAttribute.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Helpers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Authorization;
    using Microsoft.AspNetCore.Mvc.Filters;
    using TEHA.Portal.Data.Models.Account;

    /// <summary>
    /// Authorize Custom Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeCustomAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// On Authorization
        /// </summary>
        /// <param name="context">context</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (!HasAllowAnonymous(context) && user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

        /// <summary>
        /// Check context has allow anonymous
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>True, If Has AllowAnonymous</returns>
        private static bool HasAllowAnonymous(AuthorizationFilterContext context)
        {
            var filters = context.Filters;
            for (var i = 0; i < filters.Count; i++)
            {
                if (filters[i] is IAllowAnonymousFilter)
                {
                    return true;
                }
            }

            // When doing endpoint routing, MVC does not add AllowAnonymousFilters for AllowAnonymousAttributes that
            // were discovered on controllers and actions. To maintain compat with 2.x,
            // we'll check for the presence of IAllowAnonymous in endpoint metadata.
            var endpoint = context.HttpContext.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return true;
            }

            return false;
        }
    }
}
