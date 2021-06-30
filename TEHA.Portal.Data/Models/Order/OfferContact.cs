// <copyright file="OfferContact.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains offer
    /// </summary>
    public class OfferContact
    {
        /// <summary>
        /// Gets or Sets Salutation Code
        /// </summary>
        public string SalutationCode { get; set; }

        /// <summary>
        /// Gets or sets name of the owner
        /// </summary>
        /// <value>Name of the owner</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last Name
        /// </summary>
        /// <value>Last Name</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets house Number
        /// </summary>
        /// <value>House Number</value>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets street in which the person lives
        /// </summary>
        /// <value>Street in which the person lives</value>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets postal Code of the person&#x27;s area
        /// </summary>
        /// <value>Postal Code of the person&#x27;s area</value>
        [Required]
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets city of the Person
        /// </summary>
        /// <value>City of the Person</value>
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets phone Number
        /// </summary>
        /// <value>Phone Number</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        /// <value>Email</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets type of contact person, i.e., Owner, Property Manager or Other
        /// </summary>
        /// <value>Type of contact person, i.e., Owner, Property Manager or Other</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets if the selected type is Óther, then user will enter this description
        /// </summary>
        /// <value>If the selected type is Óther, then user will enter this description</value>
        public string OtherTypeDescription { get; set; }
    }
}
