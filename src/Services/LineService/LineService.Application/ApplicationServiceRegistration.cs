using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LineService.Application
{
	public static class ApplicationServiceRegistration
	{
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}

