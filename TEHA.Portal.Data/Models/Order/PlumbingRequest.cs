// <copyright file="PlumbingRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TEHA.Portal.Data.Models.Common;

    /// <summary>
    /// Details for plumbing service to TEHA.
    /// </summary>
    public class PlumbingRequest
    {
        /// <summary>
        /// Gets or sets user Id to enforce authorization against user&#x27;s accessible properties
        /// </summary>
        /// <value>User Id to enforce authorization against user&#x27;s accessible properties</value>
        [Required]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets property Id
        /// </summary>
        /// <value>Property Id</value>
        [Required]
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets flat ID to locate Flat.
        /// </summary>
        /// <value>Flat ID to locate Flat.</value>
        [Required]
        public int? FlatId { get; set; }

        /// <summary>
        /// Gets or sets Order Id.
        /// </summary>
        /// <value>Order id. Only in case to edit Order data. otherwise null</value>
        public int? OrderId { get; set; }

        /// <summary>
        /// Gets or sets Meter Ids to request plumbing for.
        /// </summary>
        public List<int?> MeterIds { get; set; }

        /// <summary>
        /// Gets or Sets AlternativePerson
        /// </summary>
        public ContactPerson AlternativePerson { get; set; }

        /// <summary>
        /// Gets or sets date of Appointment with building manager.
        /// </summary>
        /// <value>Date of Appointment with building manager.</value>
        public string AppointmentDate { get; set; }

        /// <summary>
        /// Gets or Sets AlternativeDateRange
        /// </summary>
        public DateRange AlternativeDateRange { get; set; }

        /// <summary>
        /// Gets or Sets PreferredTimeRange
        /// </summary>
        public TimeRange PreferredTimeRange { get; set; }

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
        /// Gets or sets reason of the plumbing order.
        /// </summary>
        /// <value>Reason of the plumbing order.</value>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or Sets CommunicationMode
        /// </summary>
        public CommunicationMode CommunicationMode { get; set; }

        /// <summary>
        /// Gets or sets any notes or remarks by the User
        /// </summary>
        /// <value>Any notes or remarks by the User</value>
        public string Comments { get; set; }

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
