using AutoMapper;
using Application.AutoMappers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Service.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registrar mapeamentos automaticamente funciona apenas se  as classes Automapper Profile estão no projeto ASP.NET

            AutoMapperConfig.RegisterMappings();
        }
    }
}
