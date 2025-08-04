// <copyright file="DependencyInjection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Infrastructure
{
    using BankingApp.Core.Interfaces;
    using BankingApp.Infrastructure.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Provides extension methods for registering infrastructure dependencies.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers infrastructure services with the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to add services to.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            // Register your infrastructure services here
            // Example: services.AddScoped<IMyService, MyService>();
            services.AddSingleton<IBankAccountRepository, BankAccountRepository>();
            return services;
        }
    }
}
