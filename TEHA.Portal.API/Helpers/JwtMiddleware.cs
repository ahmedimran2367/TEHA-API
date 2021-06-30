// <copyright file="JwtMiddleware.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.API.Helpers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;

    /// <summary>
    /// Contain Toke realted Methods
    /// </summary>
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;
        private readonly Configuration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtMiddleware"/> class.
        /// </summary>
        /// <param name="next">RequestDelegate</param>
        /// <param name="configuration">Configuration</param>
        public JwtMiddleware(RequestDelegate next, Configuration configuration)
        {
            this.next = next;
            this.configuration = configuration;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                this.AttachUserToContext(context, token);
            }

            await this.next(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(this.configuration.Secret);
                tokenHandler.ValidateToken(
                    token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero, // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                // attach user to context on successful jwt validation
                var claim = jwtToken.Claims.FirstOrDefault(x => x.Type == "unique_name").Value;
                var u = JsonConvert.DeserializeObject<Data.Models.Account.User>(claim);
                context.Items["User"] = u;
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
