// <copyright file="ServiceContactInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Info
{
    /// <summary>
    /// Contains contact person details
    /// </summary>
    public class ServiceContactInfo
    {
        /// <summary>
        /// Gets or sets peron name who&#x27;s serves that respected service request.
        /// </summary>
        /// <value>Peron name who&#x27;s serves that respected service request.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets email address of the contact persion.
        /// </summary>
        /// <value>Email address of the contact persion.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets tel Number
        /// </summary>
        /// <value>Tel Number</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets Office Hours
        /// </summary>
        /// <value>Office Hours</value>
        public string OfficeHours { get; set; }
    }
}
