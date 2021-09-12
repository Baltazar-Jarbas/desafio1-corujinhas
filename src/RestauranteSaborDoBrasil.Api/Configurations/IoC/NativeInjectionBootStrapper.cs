﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestauranteSaborDoBrasil.Application.Events.Log;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Infra.Data.Repositories.Base;
using RestauranteSaborDoBrasil.Infra.Data.UoW;

namespace RestauranteSaborDoBrasil.Api.Configurations.IoC
{
    public static class NativeInjectionBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            RegisterInfraService(services);
            RegisterDomainServices(services);
            RegisterApplicationServices(services);
            return services;
        }

        public static void RegisterInfraService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IHandler<DomainNotification>, DomainNotificationHandler>();
        }

        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<LogEvent>, RegisterLogEventHandler>();
        }
    }
}
