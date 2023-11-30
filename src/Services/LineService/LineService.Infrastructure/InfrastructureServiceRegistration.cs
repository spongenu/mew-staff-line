using System;
using CommonModel;
using LineService.Application.Contracts.Services;
using LineService.Infrastructure.Data;
using LineService.Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LineService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ILineServiceRepository, LineServiceRepository>();

            //services.AddScoped<IMenuMasterRepository, MenuMasterRepository>();
            //services.AddScoped<IPrivilegeGrpcRepository, PrivilegeGrpcRepository>();

            //services.AddTransient<IMasterDataContext, MasterDataContext>();

            //services.AddGrpcClient<PrivilegeProtoService.PrivilegeProtoServiceClient>
            //       (o => o.Address = new Uri(configuration["GrpcSettings:PrivilegeServiceUrl"]));

            ////MassTransit - RabbitMQ Configuration
            //services.AddMassTransit(config =>
            //{
            //    config.UsingRabbitMq((ctx, cfg) =>
            //    {
            //        cfg.Host(configuration["EventBusSettings:HostAddress"]);
            //    });
            //});

            services.AddTransient<ILineContext, LineContext>();
            services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));

            return services;
        }
    }
}


