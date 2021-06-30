// <copyright file="JWTTokenGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MWCIA.OAR.API
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Logging;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;

    /// <summary>
    /// JWT Token Generator
    /// </summary>
    public static class JwtTokenGenerator
    {
        /// <summary>
        /// Generates JWT Token. It only takes one parameter that is JsonString. as the name suggests its a string with Json
        /// </summary>
        /// <param name="jsonString">JSON</param>
        /// <param name="jwtKey">Jwt Key</param>
        /// May contain the whole user object
        /// <returns>Token</returns>
        public static string GenerateToken(string jsonString, string jwtKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();  // Create a TokenHandler object which can create tokens.
            var key = Encoding.ASCII.GetBytes(jwtKey); // Convert key to bytes
            IdentityModelEventSource.ShowPII = true;
            var tokenDescriptor = new SecurityTokenDescriptor // Create Token Descriptor Object. Contains Subject [is a Claim Which contains Name (User) and Value (Json)], Expires (When token will expire), SigningCredentials (Key and the algo to use for encryptiion)
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, jsonString),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor); // will create a securityToken in a SecurityToken Class
            return tokenHandler.WriteToken(token); // this will return Token as a string.
        }

        /// <summary>
        /// Implements Generate Refresh Token
        /// </summary>
        /// <param name="jsonString">JSON</param>
        /// <param name="jwtKey">Jwt Key</param>
        /// <returns>Refresh Token</returns>
        public static string GenerateRefreshToken(string jsonString, string jwtKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();  // Create a TokenHandler object which can create tokens.
            var key = Encoding.ASCII.GetBytes(jwtKey); // Convert key to bytes
            IdentityModelEventSource.ShowPII = true;
            var tokenDescriptor = new SecurityTokenDescriptor // Create Token Descriptor Object. Contains Subject [is a Claim Which contains Name (User) and Value (Json)], Expires (When token will expire), SigningCredentials (Key and the algo to use for encryptiion)
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, jsonString),
                }),
                Expires = DateTime.UtcNow.AddHours(16),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor); // will create a securityToken in a SecurityToken Class
            return tokenHandler.WriteToken(token); // this will return Token as a string.
        }

        /// <summary>
        /// Check refresh token is valid
        /// </summary>
        /// <param name="jwtKey">JwtKey</param>
        /// <param name="user">User</param>
        /// <returns>True, If refreash token is valid.</returns>
        public static bool IsValidRefreshToken(string jwtKey, TEHA.Portal.Data.Models.Account.User user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtKey);
                tokenHandler.ValidateToken(
                    user.RefreshToken,
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
                var u = JsonConvert.DeserializeObject<TEHA.Portal.Data.Models.Account.User>(claim);
                user.ExternalToken = u.ExternalToken;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
