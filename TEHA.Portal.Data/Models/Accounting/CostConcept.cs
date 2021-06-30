// <copyright file="CostConcept.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Accounting
{
    using System.Collections.Generic;

    /// <summary>
    /// Cost Concept
    /// </summary>
    public class CostConcept
    {
        /// <summary>
        /// Gets or sets concept Id
        /// </summary>
        public int ConceptId { get; set; }

        /// <summary>
        /// Gets or sets property Id
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Gets or sets payrollYear Id
        /// </summary>
        public int PayrollYearId { get; set; }

        /// <summary>
        /// Gets or sets concept Code
        /// </summary>
        public int? ConceptCode { get; set; }

        /// <summary>
        /// Gets or sets vat
        /// </summary>
        public double? Vat { get; set; }

        /// <summary>
        /// Gets or sets description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets cost Concept Spliting Type
        /// </summary>
        public string SplittingType { get; set; }

        /// <summary>
        /// Gets or sets total Amount Last Period
        /// </summary>
        public decimal? TotalAmountLastPeriod { get; set; }

        /// <summary>
        /// Gets or sets if true, then concept is edit able.
        /// </summary>
        public bool? EditableInd { get; set; }

        /// <summary>
        /// Gets or sets list of cost
        /// </summary>
        public List<CostDetail> Cost { get; set; }

        /// <summary>
        /// Gets or sets contains Quantities of energy cost
        /// </summary>
        public EnergyCostQuantity Quantities { get; set; }

        /// <summary>
        /// Gets or sets CalculationKey
        /// </summary>
        public string CalculationKey { get; set; }

        /// <summary>
        /// Gets or sets Units
        /// </summary>
        public string Units { get; set; }

        /// <summary>
        /// Gets or sets comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets delete Indicator
        /// </summary>
        public bool DeleteInd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Internal Indicator
        /// </summary>
        public bool InternalInd { get; set; }
    }
}
