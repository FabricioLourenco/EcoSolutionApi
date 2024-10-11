using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;
using EcoSolution.Infra.CrossCutting.Handlers.Jwt;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using EcoSolution.Infra.CrossCutting.Handlers.Validators;
using EcoSolution.Infra.Data.Context;
using EcoSolution.Infra.Data.Data;
using EcoSolution.Infra.Data.Repositories;
using EcoSolution.Service.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Scrutor;
using System.Reflection;
using System.Text;

namespace EcoSolution.Infra.CrossCutting.Ioc
{
    public static class ContainerService
    {

        public static IServiceCollection AddApplicationCollections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddNotificationHandlers();

            services.AddValidatorHandlers();

            services.RegisterAutomaticDependencies(assembly => assembly.FullName.StartsWith("EcoSolution.Service"));

            services.RegisterAutomaticDependencies(assembly => assembly.FullName.StartsWith("EcoSolution.Infra.Data"));

            services.AddValidators();

            services.AddJwtHandlers();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(ILoggerService), typeof(LoggerService));

            services.AddScoped(typeof(INotificationHandler), typeof(NotificationHandler));

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IArquivoRepository, ArquivoRepository>();
            services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
            services.AddScoped<IManualRepository, ManualRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }

        #region Validators

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.Load("EcoSolution.Service"));
            return services;
        }

        #endregion

        #region Authentication 

        public static IServiceCollection AddApplicationAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtHandler:PrivateKey").Value)),
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     RequireExpirationTime = true,
                     ClockSkew = TokenValidationParameters.DefaultClockSkew
                 };
             });
            return services;
        }

        #endregion

        #region Context

        public static IServiceCollection AddApplicationContext(this IServiceCollection services, string queryString)
        {
            services.AddDbContext<EcoSolutionContext>(
                options => options.UseNpgsql(queryString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
                }));
            return services;
        }

        #endregion

        #region Notification

        public static IServiceCollection AddNotificationHandlers(this IServiceCollection services)
        {
            services.AddScoped(typeof(INotificationHandler), typeof(NotificationHandler));
            return services;
        }

        #endregion

        #region Automatic Dependencies

        public static void RegisterAutomaticDependencies(this IServiceCollection services, Func<Assembly, bool> assemblyFilter)
        {
            services.Scan(delegate (ITypeSourceSelector selector)
            {
                selector.FromApplicationDependencies(assemblyFilter).AddClasses(delegate (IImplementationTypeFilter typeFilter)
                {
                    typeFilter.AssignableTo<IScopedDependency>();
                }).AsImplementedInterfaces()
                    .WithScopedLifetime();
                selector.FromApplicationDependencies(assemblyFilter).AddClasses(delegate (IImplementationTypeFilter typeFilter)
                {
                    typeFilter.AssignableTo<ISingletonDependency>();
                }).AsImplementedInterfaces()
                    .WithSingletonLifetime();
                selector.FromApplicationDependencies(assemblyFilter).AddClasses(delegate (IImplementationTypeFilter typeFilter)
                {
                    typeFilter.AssignableTo<ITransientDependency>();
                }).AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }

        #endregion

        #region JwtHandler

        public static IServiceCollection AddJwtHandlers(this IServiceCollection services)
        {
            services.AddScoped(typeof(IJwtHandler), typeof(JwtHandler));
            return services;
        }

        #endregion

        #region Validator Handlers

        public static IServiceCollection AddValidatorHandlers(this IServiceCollection services)
        {
            services.AddScoped(typeof(IValidatorHandler), typeof(ValidatorHandler));
            return services;
        }

        #endregion
      
    }
}
