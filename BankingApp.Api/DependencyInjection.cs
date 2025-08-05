// <copyright file="DependencyInjection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Api
{
    using BankingApp.Application;
    using BankingApp.Core;
    using BankingApp.Infrastructure;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Provides extension methods for registering API dependencies for the BankingApp application.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers API services and dependencies for the BankingApp application.
        /// </summary>
        /// <param name="services">The service collection to add dependencies to.</param>
        /// <param name="configuration">The application configuration.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your API services here
            // Example: services.AddControllers();
            services.AddApplicationDI().AddInfrastructureDI().AddCoreDI(configuration);
            return services;
        }
    }
}

// This code registers the API services and dependencies for the BankingApp application.