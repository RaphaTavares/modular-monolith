﻿using Evently.Common.Infrastructure.Outbox;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Ticketing.Application.Abstractions.Data;
using Evently.Modules.Ticketing.Application.Carts;
using Evently.Modules.Ticketing.Domain.Customers;
using Evently.Modules.Ticketing.Infrastructure.Customers;
using Evently.Modules.Ticketing.Infrastructure.Database;
using Evently.Modules.Ticketing.Infrastructure.PublicApi;
using Evently.Modules.Ticketing.PublicApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Ticketing.Infrastructure;
public static class TicketingModule
{
    public static IServiceCollection AddTicketingModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TicketingDbContext>());

        services.AddSingleton<CartService>();

        services.AddScoped<ITicketingApi, TicketingApi>();

    }
}