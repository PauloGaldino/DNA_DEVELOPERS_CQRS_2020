using Application.Interfaces;
using Application.Services.Clientes;
using Application.Services.Produtos;
using CrossCuting.Identity.Authorizations;
using CrossCuting.Identity.Models;
using CrossCuting.Identity.Services;
using CrossCutting.Bus;
using Domain.Core.Bus;
using Domain.Core.Events.Interfaces;
using Domain.Core.Notifications;
using Domain.EventHandler;
using Domain.Events.Clientes;
using Domain.Events.Produtos;
using Domain.Interfaces;
using Domain.Interfaces.DNA.Domain.Interfaces;
using Infra.Data.Datas.Context;
using Infra.Data.EventSourcing;
using Infra.Data.Repository.Clientes;
using Infra.Data.Repository.EventSourcing;
using Infra.Data.Repository.EventSourcing.Interfaces;
using Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();
            #region depois que implematar a camada de application

            // Application
            //===================================================================================================
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();

            //services.AddScoped<ICategoriaAppService, CategoriaAppService>();

            //services.AddScoped<IFornecedorAppService, FornecedorAppService>();

            //services.AddScoped<IExpedidorAppService, ExpedidorAppService>();

            //services.AddScoped<IEmpregadoAppService, EmpregadoAppService>();
            #endregion

            //Domaain
            //=================================================================================================== 
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            // Domain - Events 
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Cliente
            services.AddScoped<INotificationHandler<ClienteRegisteredEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<ClienteUpdatedEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<ClienteRemovedEvent>, ClienteEventHandler>();

            //Produto
            services.AddScoped<INotificationHandler<ProdutoRegisteredEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<ProdutoUpdatedEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<ProdutoRemovedEvent>, ProdutoEventHandler>();

            #region para descomentar
            ////Categoria
            //services.AddScoped<INotificationHandler<CategoriaRegisteredEvent>, CategoriaEventHandler>();
            //services.AddScoped<INotificationHandler<CategoriaUpdatedEvent>, CategoriaEventHandler>();
            //services.AddScoped<INotificationHandler<CategoriaRemovedEvent>, CategoriaEventHandler>();

            ////Fornecedor
            //services.AddScoped<INotificationHandler<FornecedorRegisteredEvent>, FornecedorEventHandler>();
            //services.AddScoped<INotificationHandler<FornecedorUpdatedEvent>, FornecedorEventHandler>();
            //services.AddScoped<INotificationHandler<FornecedorRemovedEvent>, FornecedorEventHandler>();

            ////Expedidor
            //services.AddScoped<INotificationHandler<ExpedidorRegisteredEvent>, ExpedidorEventHandler>();
            //services.AddScoped<INotificationHandler<ExpedidorUpdatedEvent>, ExpedidorEventHandler>();
            //services.AddScoped<INotificationHandler<ExpedidorRemovedEvent>, ExpedidorEventHandler>();

            ////Empregado
            //services.AddScoped<INotificationHandler<EmpregadoRegisteredEvent>, EmpregadoEventHandler>();
            //services.AddScoped<INotificationHandler<EmpregadoUpdatedEvent>, EmpregadoEventHandler>();
            //services.AddScoped<INotificationHandler<EmpregadoRemovedEvent>, EmpregadoEventHandler>();

            //// Domain - Commands
            ////Cliente
            //services.AddScoped<IRequestHandler<RegisterNewClienteCommand, bool>, ClienteCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateClienteCommand, bool>, ClienteCommandHandler>();
            //services.AddScoped<IRequestHandler<RemoveClienteCommand, bool>, ClienteCommandHandler>();

            ////Categoria
            //services.AddScoped<IRequestHandler<RegisterNewCategoriaCommand, bool>, CategoriaCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateCategoriaCommand, bool>, CategoriaCommandHandler>();
            //services.AddScoped<IRequestHandler<RemoveCategoriaCommand, bool>, CategoriaCommandHandler>();

            ////Fornecedores
            //services.AddScoped<IRequestHandler<RegisterNewFornecedorCommand, bool>, FornecedorCommandtHandler>();
            //services.AddScoped<IRequestHandler<UpdateFornecedorCommand, bool>, FornecedorCommandtHandler>();
            //services.AddScoped<IRequestHandler<RemoveFornecedorCommand, bool>, FornecedorCommandtHandler>();

            ////Expedidores
            //services.AddScoped<IRequestHandler<RegisterNewExpedidorCommand, bool>, ExpedidorCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateExpedidorCommand, bool>, ExpedidorCommandHandler>();
            //services.AddScoped<IRequestHandler<RemoveExpedidorCommand, bool>, ExpedidorCommandHandler>();


            ////Empregados
            //services.AddScoped<IRequestHandler<RegisterNewEmpregadoCommand, bool>, EmpregadoCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateEmpregadoCommand, bool>, EmpregadoCommandHandler>();
            //services.AddScoped<IRequestHandler<RemoveEmpregadoCommand, bool>, EmpregadoCommandHandler>();
            #endregion

            //Infrastructure
            //=====================================================================================================
            // Infra - Data
            //Repository
            //Cliente
            services.AddScoped<IClienteRepository, ClienteRepository>();

            #region para descomentar
            ////Categoria
            //services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            ////Fornecedor
            //services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            ////Expedidor
            //services.AddScoped<IExpedidorRepository, ExpedidorRepository>();

            ////Empregado
            //services.AddScoped<IEmpregadoRepository, EmpregadoRepository>();
            #endregion

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DnaDbContext>();

            // Infra - Data 
            //EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<EventStoreDbContext>();

            // Infra - Identity 
            //Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
