using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace CompanyEmployees.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
        
    }

    public static void ConfigureIIS(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {
            options.AutomaticAuthentication = false;
            options.ForwardClientCertificate = true;
        });

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        });
    }
    
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddScoped<ILoggerManager, LoggerManager>();
}