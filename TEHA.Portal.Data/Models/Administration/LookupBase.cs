// <copyright file="LookupBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Administration
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains system lookups
    /// </summary>
    public class LookupBase
    {
        /// <summary>
        /// Gets or sets module - profile   Mail/Post, Email, SMS
        /// </summary>
        /// <value>module - profile   Mail/Post, Email, SMS</value>
        public List<LookUps> CommunicationChannel { get; set; }

        /// <summary>
        /// Gets or sets module - (profile(contract,my team),offer request)   Rental Service
        /// </summary>
        /// <value>module - (profile(contract,my team),offer request)   Rental Service</value>
        public List<LookUps> ContractType { get; set; }

        /// <summary>
        /// Gets or sets module - Meter Overview
        /// </summary>
        /// <value>module - Meter Overview</value>
        public List<LookUps> MeasuringInstrumentType { get; set; }

        /// <summary>
        /// Gets or sets module - stockOverview
        /// </summary>
        /// <value>module - stockOverview</value>
        public List<LookUps> TestType { get; set; }

        /// <summary>
        /// Gets or sets module - Plumbing order
        /// </summary>
        /// <value>module - Plumbing order</value>
        public List<LookUps> PlumbingReason { get; set; }

        /// <summary>
        /// Gets or sets module - Energy performance certificate
        /// </summary>
        /// <value>module - Energy performance certificate</value>
        public List<LookUps> BuildingType { get; set; }

        /// <summary>
        /// Gets or sets module - Energy performance certificate
        /// </summary>
        /// <value>module - Energy performance certificate</value>
        public List<LookUps> EnergySource { get; set; }

        /// <summary>
        /// Gets or sets module - Accounting
        /// </summary>
        /// <value>module - Accounting </value>
        public List<CostLookUp> HeatingCostType { get; set; }

        /// <summary>
        /// Gets or sets module - Accounting
        /// </summary>
        /// <value>module - Accounting</value>
        public List<CostLookUp> EnergyCostType { get; set; }

        /// <summary>
        /// Gets or sets module - Accounting
        /// </summary>
        /// <value>module - Accounting</value>
        public List<CostLookUp> HouseCostType { get; set; }

        /// <summary>
        /// Gets or sets module - Document Archives
        /// </summary>
        /// <value>module - Document Archives</value>
        public List<LookUps> DocumentType { get; set; }

        /// <summary>
        /// Gets or sets module - Offer request
        /// </summary>
        /// <value>module - Offer request</value>
        public List<LookUps> ServiceType { get; set; }

        /// <summary>
        /// Gets or sets module - Accounting
        /// </summary>
        public List<CostLookUp> AdditionalHeatingCostType { get; set; }

        /// <summary>
        /// Gets or sets module - Accounting
        /// </summary>
        /// <value>module - Accounting</value>
        public List<CostLookUp> AdditionalHotWaterCostType { get; set; }

        /// <summary>
        /// Gets or sets module - StockOverview
        /// </summary>
        public List<LookUps> RwmStatus { get; set; }

        /// <summary>
        /// Gets or sets module - StockOverview
        /// </summary>
        public List<LookUps> AccountingStatus { get; set; }

        /// <summary>
        /// Gets or sets module - StockOverview
        /// </summary>
        public List<LookUps> ReadingStatus { get; set; }

        /// <summary>
        /// Gets or sets module - StockOverview
        /// </summary>
        public List<LookUps> PlumbingStatus { get; set; }

        /// <summary>
        /// Gets or sets module - Accounting
        /// </summary>
        /// <value>module - Accounting</value>
        public List<LookUps> MeasurementUnit { get; set; }

        /// <summary>
        /// Gets or sets module - Orders
        /// </summary>
        /// <value>module - Orders</value>
        public List<LookUps> OrderType { get; set; }

        /// <summary>
        /// Gets or sets module - Orders
        /// </summary>
        /// <value>module - Orders</value>
        public List<LookUps> OrderStatus { get; set; }

        /// <summary>
        /// Gets or sets module - Orders
        /// </summary>
        /// <value>module - Orders</value>
        public List<LookUps> Location { get; set; }

        /// <summary>
        /// Gets or sets module - Orders
        /// </summary>
        /// <value>module - Orders</value>
        public List<LookUps> CalculationKey { get; set; }

        /// <summary>
        /// Gets or sets Salutation
        /// </summary>
        public List<LookUps> Salutation { get; set; }

        /// <summary>
        /// Gets or sets Extractionpoints
        /// </summary>
        /// <value>module - Orders</value>
        public List<LookUps> Extractionpoints { get; set; }

        /// <summary>
        /// Gets or sets InvoiceStatus
        /// </summary>
        /// <value>module - Orders</value>
        public List<LookUps> InvoiceStatus { get; set; }

        /// <summary>
        /// Gets or sets InvoiceStatus
        /// </summary>
        /// <value>module - Orders</value>
        public List<LookUps> ReadingType { get; set; }

        /// <summary>
        /// Gets or sets WageShareType
        /// </summary>
        /// <value>module - Orders</value>
        public List<LookUps> WageShareType { get; set; }
    }
}
