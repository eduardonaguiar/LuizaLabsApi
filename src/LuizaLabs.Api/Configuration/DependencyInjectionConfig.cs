using Equinox.Infra.Data.UoW;
using LuizaLabs.Application.Interfaces;
using LuizaLabs.Application.Services;
using LuizaLabs.Domain.Commands.Customer;
using LuizaLabs.Domain.Commands.Favorites;
using LuizaLabs.Domain.Core.Bus;
using LuizaLabs.Domain.Core.Events;
using LuizaLabs.Domain.Core.Interfaces;
using LuizaLabs.Domain.Core.Notifications;
using LuizaLabs.Domain.DomainService;
using LuizaLabs.Domain.Events;
using LuizaLabs.Domain.Events.Favorites;
using LuizaLabs.Domain.Interfaces;
using LuizaLabs.Infra.CrossCutting.Identity.Authorization;
using LuizaLabs.Infra.CrossCutting.Identity.Models;
using LuizaLabs.Infra.Data.Context;
using LuizaLabs.Infra.Data.EventSourcing;
using LuizaLabs.Infra.Data.Repository;
using LuizaLabs.Infra.Data.Repository.EventSourcing;
using LuizaLabs.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace LuizaLabs.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IFavoritesAppService, FavoritesAppService>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerAddEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<AddProductEvent>, FavoritesEventHandler>();
            services.AddScoped<INotificationHandler<RemoveProductEvent>, FavoritesEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<AddProductCommand, bool>, FavoritesCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, bool>, FavoritesCommandHandler>();

            // Domain - Service 
            //services.AddScoped<IProductSearchService, ProductSearchService>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IFavoritesRepository, FavoriteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LuizaLabsContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreContext>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();

            
        }
    }
}
