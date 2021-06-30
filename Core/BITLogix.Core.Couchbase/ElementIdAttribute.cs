// <copyright file="ElementIdAttribute.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BITLogix.Core.Couchbase
{
    using System;

    /// <summary>
    /// ElementId attribute
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ElementIdAttribute : Attribute
    {
        private readonly string elementId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementIdAttribute"/> class.
        /// </summary>
        /// <param name="elementId">Element ID string</param>
        public ElementIdAttribute(string elementId)
        {
            this.elementId = elementId;
        }

        /// <summary>
        /// Gets ElementId
        /// </summary>
        public string ElementId
        {
            get { return this.elementId; }
        }
    }
}
