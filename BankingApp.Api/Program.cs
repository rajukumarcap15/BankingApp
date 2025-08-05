// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace BankingApp.Api
{
    using BankingApp.Api.Middleware;
    using BankingApp.Core.Validators;
    using FluentValidation;

    /// <summary>
    /// Entry point for the Banking System API application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method to configure and run the web application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure logging
            builder.Logging.ClearProviders(); // Optional: removes default providers
            builder.Logging.AddConsole();     // Adds console logging

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApiDI(builder.Configuration); // Register API services
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateBankAccountDtoValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}