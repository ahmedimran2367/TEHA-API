// <copyright file="ContactPerson.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    /// <summary>
    /// Contains contact person details
    /// </summary>
    public class ContactPerson
    {
        /// <summary>
        /// Gets or Sets Salutation Code
        /// </summary>
        public string SalutationCode { get; set; }

        /// <summary>
        /// Gets or sets first Name
        /// </summary>
        /// <value>First Name </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last Name
        /// </summary>
        /// <value>Last Name</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        /// <value>Email</value>
        public string Email { get; set; }

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
    }
}
