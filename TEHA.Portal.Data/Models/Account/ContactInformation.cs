// <copyright file="ContactInformation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Account
{
    /// <summary>
    /// Contact Information
    /// </summary>
    public class ContactInformation
    {
        /// <summary>
        /// Gets or Sets Salutation Code
        /// </summary>
        public string SalutationCode { get; set; }

        /// <summary>
        /// Gets or Sets First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets Street Address
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or Sets Postcode
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or Sets Place
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Additional Emails
        /// </summary>
        public AdditionalEmail[] AdditionalEmails { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or Sets Mobile number
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or Sets Fax
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or Sets Customer Number. For use in Accounting only
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Gets or Sets Latitude
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// Gets or Sets Longitude
        /// </summary>
        public decimal? Longitude { get; set; }

        /// <summary>
        /// Gets or Sets SecondarySalutation Code
        /// </summary>
        public string SecondarySalutationCode { get; set; }

        /// <summary>
        /// Gets or Sets Secondary First Name
        /// </summary>
        public string SecondaryFirstName { get; set; }

        /// <summary>
        /// Gets or Sets Secondary Last Name
        /// </summary>
        public string SecondaryLastName { get; set; }

        /// <summary>
        /// Gets or Sets Secondary Street
        /// </summary>
        public string SecondaryStreet { get; set; }

        /// <summary>
        /// Gets or Sets Secondary Postcode
        /// </summary>
        public string SecondaryPostcode { get; set; }

        /// <summary>
        /// Gets or Sets Secondary Place
        /// </summary>
        public string SecondaryPlace { get; set; }

        /// <summary>
        /// Gets or Sets SecondaryEmail
        /// </summary>
        public string SecondaryEmail { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether SameAddressInd is true or false
        /// </summary>
        public bool SameAddressInd { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether SameEmailInd is true or false
        /// </summary>
        public bool SameEmailInd { get; set; }

        /// <summary>
        /// Gets or sets schedule Available
        /// </summary>
        public string ScheduleAvailable { get; set; }
    }
}
