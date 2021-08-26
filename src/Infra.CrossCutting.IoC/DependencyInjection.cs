using Application.Services;
using Domain.Interfaces.Notification;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Interfaces.UoW;
using Domain.Notifications;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ContextoEntity>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPedidoService, PedidoService>();

            return services;
        }
    }
}