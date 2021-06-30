// <copyright file="Recepient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    /// <summary>
    /// Recepient info will be empty if user does not select the different recepient checkbox
    /// </summary>
    public class Recepient
    {
        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets postcode
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets area
        /// </summary>
        public string Area { get; set; }
    }
}
