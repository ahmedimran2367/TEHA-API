// <copyright file="LanguageBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TEHA.Portal.Data.Models.Language
{
    /// <summary>
    /// Contains language specific details
    /// </summary>
    public class LanguageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageBase"/> class.
        /// </summary>
        public LanguageBase()
        {
            this.Home = new Home();
            this.Info = new Info();
            this.Account = new Account();
            this.Admin = new Admin();
            this.Order = new Order();
            this.StockOverview = new StockOverview();
            this.Accounting = new Accounting();
            this.Lookup = new Lookup();
            this.DocumentArchives = new DocumentArchives();
            this.Miscellaneous = new Miscellaneous();
        }

        /// <summary>
        /// Gets or sets module
        /// </summary>
        public Home Home { get; set; }

        /// <summary>
        /// Gets or sets module
        /// </summary>
        public Info Info { get; set; }

        /// <summary>
        /// Gets or sets module
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Gets or sets module
        /// </summary>
        public Admin Admin { get; set; }

        /// <summary>
        /// Gets or sets module
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets module
        /// </summary>
        public StockOverview StockOverview { get; set; }

        /// <summary>
        /// Gets or sets module
        /// </summary>
        public Accounting Accounting { get; set; }

        /// <summary>
        /// Gets or sets module
        /// </summary>
        public Lookup Lookup { get; set; }

        /// <summary>
        /// Gets or Sets module
        /// </summary>
        public DocumentArchives DocumentArchives { get; set; }

        /// <summary>
        /// Gets or Sets Miscellaneous
        /// </summary>
        public Miscellaneous Miscellaneous { get; set; }
    }
}
