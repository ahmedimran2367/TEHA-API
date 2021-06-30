// <copyright file="ReadingRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// For Year-end and/or Interim Reading
    /// </summary>
    public class ReadingRequest
    {
        /// <summary>
        /// Gets or sets user Id
        /// </summary>
        /// <value>User Id</value>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets property ID
        /// </summary>
        /// <value>Property ID</value>
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets flat ID
        /// </summary>
        /// <value>Flat ID</value>
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or sets Order Id.
        /// </summary>
        /// <value>Order id. Only in case to edit Order data. otherwise null</value>
        public int? OrderId { get; set; }

        /// <summary>
        /// Gets or sets Meter ID
        /// </summary>
        /// <value>Meter ID</value>
        public int? MeterId { get; set; }

        /// <summary>
        /// Gets or sets date of Appointment
        /// </summary>
        /// <value>Date of Appointment</value>
        public string AppointmentDate { get; set; }

        /// <summary>
        /// Gets or sets any notes or remarks by the User
        /// </summary>
        /// <value>Any notes or remarks by the User</value>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or Sets AlternativePerson
        /// </summary>
        public ContactPerson AlternativePerson { get; set; }

        /// <summary>
        /// Gets or Sets AlternativeDateRange
        /// </summary>
        public DateRange AlternativeDateRange { get; set; }

        /// <summary>
        /// Gets or Sets PreferredTimeRange
        /// </summary>
        public TimeRange PreferredTimeRange { get; set; }

        /// <summary>
        /// Gets or Sets CommunicationMode
        /// </summary>
        public CommunicationMode CommunicationMode { get; set; }

        /// <summary>
        /// Gets or Sets UserMovingOut
        /// </summary>
        public UserMovingDetail UserMovingOut { get; set; }

        /// <summary>
        /// Gets or Sets UserMovingIn
        /// </summary>
        public UserMovingDetail UserMovingIn { get; set; }

        /// <summary>
        /// Gets or sets Telephone
        /// </summary>
        /// <value>Phone</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        /// <value>Mobile</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets always be true. Terms &amp; conditions and cancellation policy
        /// </summary>
        /// <value>Always be true. Terms &amp; conditions and cancellation policy</value>
        public bool? TermsInd { get; set; }

        /// <summary>
        /// Gets or sets always be true. Bear the costs, provided that the measuring device is not defective or there is no warranty claim
        /// </summary>
        /// <value>Always be true. Bear the costs, provided that the measuring device is not defective or there is no warranty claim</value>
        public bool? CostsInd { get; set; }

        /// <summary>
        /// Gets or sets always be true. Declaration on data protection and agree to the storage of data for the period until the purpose is fulfilled
        /// </summary>
        /// <value>Always be true. Declaration on data protection and agree to the storage of data for the period until the purpose is fulfilled</value>
        public bool? DataProtectionInd { get; set; }
    }
}
