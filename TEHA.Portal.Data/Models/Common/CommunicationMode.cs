// <copyright file="CommunicationMode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Common
{
    /// <summary>
    /// Contains communication chanels
    /// </summary>
    public class CommunicationMode
    {
        /// <summary>
        /// Gets or sets letter
        /// </summary>
        /// <value>Letter</value>
        public bool? LetterInd { get; set; }

        /// <summary>
        /// Gets or sets sMS
        /// </summary>
        /// <value>SMS</value>
        public bool? SmsInd { get; set; }

        /// <summary>
        /// Gets or sets email
        /// </summary>
        /// <value>Email</value>
        public bool? EmailInd { get; set; }

        /// <summary>
        /// Gets or sets web Portal
        /// </summary>
        /// <value>Web Portal</value>
        public bool? WebPortalInd { get; set; }
    }
}
