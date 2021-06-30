// <copyright file="Invoice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Document
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains invoice details
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Gets or sets invoice Id (PK)
        /// </summary>
        /// <value>Invoice Id (PK)</value>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets property Id
        /// </summary>
        /// <value>Property Id</value>
        [Required]
        public int? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets TehaLgNo
        /// </summary>
        /// <value>Teha Lg No</value>
        public string TehaLgNo { get; set; }

        /// <summary>
        /// Gets or sets AdminLgNo
        /// </summary>
        /// <value>AdminLgNo</value>
        public string AdminLgNo { get; set; }

        /// <summary>
        /// Gets or sets Address
        /// </summary>
        /// <value>Address (Street, Postcode, City)</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets serial number of Invoice
        /// </summary>
        /// <value>Serial number of Invoice</value>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// Gets or sets document Description (Document Title)
        /// </summary>
        /// <value>Document Description (Document Title)</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets invoice amount
        /// </summary>
        /// <value>Invoice amount</value>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets date of Invoice
        /// </summary>
        /// <value>Date of Invoice</value>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets status of invoice, i.e., Paid or Unpaid
        /// </summary>
        /// <value>Status of invoice, i.e., Paid or Unpaid</value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets date on which the Invoice is paid (if status is paid)
        /// </summary>
        /// <value>Date on which the Invoice is paid (if status is paid)</value>
        public string PaidOn { get; set; }

        /// <summary>
        /// Gets or sets remaining balance
        /// </summary>
        /// <value>Remaining balance</value>
        public decimal? Balance { get; set; }

        /// <summary>
        /// Gets or Sets type of Document
        /// </summary>
        public string Type { get; set; }
    }
}
