// <copyright file="Flat.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Details of flat for displaying and searching
    /// </summary>
    public class Flat
    {
        /// <summary>
        /// Gets or sets flat Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets property Id
        /// </summary>
        [Required]
        public int PropertyId { get; set; }

        /// <summary>
        /// Gets or sets TEHA User No, a unique number assigned to user/flat by TEHA.
        /// </summary>
        public string TehaUserNo { get; set; }

        /// <summary>
        /// Gets or sets Admin User No, a unique number assigned to user/flat by Building Manager
        /// </summary>
        public string AdminUserNo { get; set; }

        /// <summary>
        /// Gets or Sets TenantName
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// Gets or sets flat number
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Gets or sets RWM status
        /// </summary>
        public string RwmStatus { get; set; }

        /// <summary>
        /// Gets or sets the status of reading request
        /// </summary>
        public string ReadingStatus { get; set; }

        /// <summary>
        /// Gets or sets plumbing Status
        /// </summary>
        public string PlumbingStatus { get; set; }

        /// <summary>
        /// Gets or sets Test Type. Applies to smoke detector only.
        /// </summary>
        public string TestType { get; set; }

        /// <summary>
        /// Gets or sets Test Date. Applies to smoke detector only.
        /// </summary>
        public DateTime? TestDate { get; set; }

        /// <summary>
        /// Gets or sets list of meters.
        /// </summary>
        public List<Meter> Meters { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Open Letter Ind is true or false.
        /// </summary>
        public bool OpenLetterInd { get; set; }
    }
}
