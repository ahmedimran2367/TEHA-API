// <copyright file="UserMovingDetail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    /// <summary>
    /// Information of User moving in. Only in case of Interim reading request
    /// </summary>
    public class UserMovingDetail
    {
        /// <summary>
        /// Gets or Sets Salutation Code
        /// </summary>
        public string SalutationCode { get; set; }

        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        /// <value>FirstName</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName
        /// </summary>
        /// <value>LastName</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Date
        /// </summary>
        /// <value>Date</value>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets phone
        /// </summary>
        /// <value>Phone</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets mobile
        /// </summary>
        /// <value>Mobile</value>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        /// <value>Mobile</value>
        public string Email { get; set; }
    }
}
