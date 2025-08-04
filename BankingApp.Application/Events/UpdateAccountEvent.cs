// <copyright file="UpdateAccountEvent.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Application.Events
{
    using MediatR;

    public record UpdateAccountEvent(string accountId) : INotification;
}

// This code defines an event called UpdateAccountEvent that implements the INotification interface from MediatR.