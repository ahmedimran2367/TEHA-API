// <copyright file="OfferRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains offer details
    /// </summary>
    public class OfferRequest
    {
        /// <summary>
        /// Gets or sets user Id to enforce authorization
        /// </summary>
        /// <value>User Id to enforce authorization</value>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets Order Id.
        /// </summary>
        /// <value>Order id. Only in case to edit Order data. otherwise null</value>
        public int? OrderId { get; set; }

        /// <summary>
        /// Gets or Sets PropertyAddress
        /// </summary>
        [Required]
        public OfferProperty PropertyAddress { get; set; }

        /// <summary>
        /// Gets or Sets ContactDetails
        /// </summary>
        [Required]
        public OfferContact ContactDetails { get; set; }

        /// <summary>
        /// Gets or sets contract Type
        /// </summary>
        /// <value>Contract Type</value>
        [Required]
        public List<string> ContractType { get; set; }

        /// <summary>
        /// Gets or sets types of services desired.
        /// </summary>
        /// <value>Types of services desired.</value>
        [Required]
        public List<string> ServiceTypes { get; set; }

        /// <summary>
        /// Gets or sets meters which are requested/already available
        /// </summary>
        /// <value>Meters which are requested/already available</value>
        public List<OfferRequestMeterTypes> MeterTypes { get; set; }

        /// <summary>
        /// Gets or sets user can select from these options as required: -No measuring device available -Devices already available -No measuring offer desired
        /// </summary>
        /// <value>User can select from these options as required: -No measuring device available -Devices already available -No measuring offer desired</value>
        public string MeasuringDeviceRequirement { get; set; }

        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether terms Indicator is true or false
        /// </summary>
        public bool TermsInd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether confirm Indicator is true or false
        /// </summary>
        public bool ConfirmInd { get; set; }
    }
}
