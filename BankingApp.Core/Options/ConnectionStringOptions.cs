// <copyright file="ConnectionStringOptions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Core.Options
{
    /// <summary>
    /// Represents the options for connection strings used in the application.
    /// </summary>
    public class ConnectionStringOptions
    {
        /// <summary>
        /// The configuration section name for connection strings.
        /// </summary>
        public const string SectionName = "ConnectionStrings";

        /// <summary>
        /// Gets or sets the default connection string.
        /// </summary>
        public string DefaultConnection { get; set; } = null!;
    }
}
