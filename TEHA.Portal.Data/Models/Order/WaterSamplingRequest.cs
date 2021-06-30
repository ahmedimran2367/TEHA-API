// <copyright file="WaterSamplingRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Order
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains water details
    /// </summary>
    public class WaterSamplingRequest
    {
        /// <summary>
        /// Gets or sets user Id to enforce authorization
        /// </summary>
        /// <value>User Id to enforce authorization</value>
        [Required]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets property Id
        /// </summary>
        /// <value>Property Id</value>
        [Required]
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets any notes or comments added by the User.
        /// </summary>
        /// <value>Any notes or comments added by the User.</value>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets always be true. Terms &amp; conditions and cancellation policy
        /// </summary>
        /// <value>Always be true. Terms &amp; conditions and cancellation policy</value>
        [Required]
        public bool? TermsInd { get; set; }

        /// <summary>
        /// Gets or sets always be true. Bear the costs, provided that the measuring device is not defective or there is no warranty claim
        /// </summary>
        /// <value>Always be true. Bear the costs, provided that the measuring device is not defective or there is no warranty claim</value>
        [Required]
        public bool? CostsInd { get; set; }

        /// <summary>
        /// Gets or Sets Question
        /// </summary>
        public Questions Questions { get; set; }
    }
}
