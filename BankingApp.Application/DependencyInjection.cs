// <copyright file="DependencyInjection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Application
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Provides extension methods for registering application dependencies.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers application services and MediatR handlers in the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to add services to.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
